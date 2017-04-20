(function () {
    'use strict';

    angular
        .module('app')
        .factory('customQuestionsSvc', customQuestionsSvc);

    customQuestionsSvc.$inject = ['appEnum'];

    function customQuestionsSvc(appEnum) {
        var service = {
            getCustomQuestionAnswer: getCustomQuestionAnswer,
            getCustomQuestionViews: getCustomQuestionViews,
            getMainQuestionTemplate: getMainQuestionTemplate
        };

        return service;

        function getCustomQuestionAnswer(questionControl, subject, questionControlType) {
            //This flag used for internal call within this service
            var returnPropFlg = questionControlType != null;

            var subjectQuestion;

            //Signature of the subject question: new question or existing with questionControlId
            var objToFind = {
                questionControlId: questionControl.questionControlId == null ?
                    questionControl.$uid :
                    questionControl.questionControlId, subjectId: subject.subjectId
            };

            if (subject.questionAnswers == null) {
                //For internal usage
                if (returnPropFlg) {
                    return undefined;
                }

                subject.questionAnswers = [];
            } else {
                subjectQuestion = _.find(subject.questionAnswers, objToFind);
            }

            //Push question to subject if null
            if (subjectQuestion == null) {
                //For internal usage
                if (returnPropFlg) {
                    return undefined;
                }

                subjectQuestion = angular.copy(objToFind);
                subjectQuestion.$uid = _.uniqueId('cqa_');
                subject.questionAnswers.push(subjectQuestion);
            }

            //For internal usage
            if (returnPropFlg) {
                var prop = getCustomQuestionAnswerProp(questionControlType);
                return subjectQuestion[prop];
            }

            return subjectQuestion;
        }

        function getCustomQuestionAnswerProp(questionControlTypeId) {
            var propName;
            switch (questionControlTypeId) {
                case appEnum.questionControlTypes.input.questionControlTypeId:
                    propName = 'stringVal';
                    break;
                case appEnum.questionControlTypes.checkbox.questionControlTypeId:
                case appEnum.questionControlTypes.radiobutton.questionControlTypeId:
                    propName = 'boolVal';
                    break;
                default:
                    throw new Error('customQuestionsSvc: questionControlTypeId is undefined! ' + questionControlTypeId);
            }

            return propName;
        }

        function getCustomQuestionViews(question, subject) {
            var views = null;

            switch (question.questionControlType) {
                case appEnum.questionControlTypes.input.questionControlTypeId:
                    views = getInputCustomQuestionView(question, subject);
                    break;
                case appEnum.questionControlTypes.checkbox.questionControlTypeId:
                    views = getCheckboxCustomQuestionView(question, subject);
                    break;
                case appEnum.questionControlTypes.radiobutton.questionControlTypeId:
                    views = getRadiobuttonCustomQuestionView(question, subject);
                    break;
            }

            return views;
        }

        function getInputCustomQuestionView(question, subject) {
            var views = _.map(question.controlList, function (control) {
                var answer = getCustomQuestionAnswer(control, subject, question.questionControlType);

                if (!answer) {
                    return null;
                }

                return createView(control.controlHeading, answer);
            });

            views = _.filter(views, function (view) { return view !== null; });

            return views;
        }

        function getCheckboxCustomQuestionView(question, subject) {
            var questionAnswers = _.map(question.controlList, function (control) {
                var boolAnswer = getCustomQuestionAnswer(control, subject, question.questionControlType);
                var stringAnswer = getCustomQuestionAnswer(control, subject, appEnum.questionControlTypes.input.questionControlTypeId);

                if (!boolAnswer) {
                    return null;
                }

                return stringAnswer ? stringAnswer : control.controlHeading;
            });

            questionAnswers = _.filter(questionAnswers, function (questionAnswer) { return questionAnswer !== null; });

            if (questionAnswers.length === 0) {
                return null;
            }

            if (question.questionHeading) {
                return [createView(question.questionHeading, _.join(questionAnswers, ', '))];
            }

            return _.map(questionAnswers, function (questionAnswer) {
                return createView(questionAnswer, 'Yes');
            });
        }

        function getRadiobuttonCustomQuestionView(question, subject) {
            var selectedControl = _.find(question.controlList, function (control) {
                return getCustomQuestionAnswer(control, subject, question.questionControlType);
            });

            if (!selectedControl) {
                return null;
            }

            var title = question.questionHeading || selectedControl.controlHeading;
            var value = question.questionHeading ? selectedControl.controlHeading : 'Yes';

            return [createView(title, value)];
        }

        function getTextareaCustomQuestionView(question, subject) {
            var control = question.controlList[0];

            if (!control) {
                return null;
            }

            var answer = getCustomQuestionAnswer(control, subject, question.questionControlType);

            if (!answer) {
                return null;
            }

            return [createView(control.controlHeading, answer)];
        }

        function getDateCustomQuestionView(question, subject) {
            var views = [];
            var dateFormat = getDateFormat(question);

            var dateFromControl = _.find(question.controlList, function (c) {
                return c.config.rules.dateRangePart === appEnum.dateRangeParts.from || _.isNil(c.config.rules.dateRangeType);
            });
            var dateToControl = _.find(question.controlList, function (c) {
                return c.config.rules.dateRangePart === appEnum.dateRangeParts.to;
            });

            var dateFromAnswer = getCustomQuestionAnswer(dateFromControl, subject, question.questionControlType);
            var dateToAnswer = dateToControl && getCustomQuestionAnswer(dateToControl, subject, question.questionControlType);
            var isTillCurrentAnswer = dateToControl && getCustomQuestionAnswer(dateToControl, subject, appEnum.questionControlTypes.radiobutton.questionControlTypeId);

            if (dateFromAnswer) {
                views.push(createView(dateFromControl.controlHeading, moment(dateFromAnswer).format(dateFormat)));
            }

            if (isTillCurrentAnswer) {
                views.push(createView(dateToControl.controlHeading, question.config.messages.tillCurrentOption));
            } else if (dateToAnswer) {
                views.push(createView(dateToControl.controlHeading, moment(dateToAnswer).format(dateFormat)));
            }

            return views;
        }

        function getDateFormat(question) {
            var dateFormat = '';
            switch (question.config.rules.dateFormat) {
                case appEnum.customDateFormats.MonthDayYear:
                    dateFormat = 'MMM DD, YYYY';
                    break;
                case appEnum.customDateFormats.MonthYear:
                    dateFormat = 'MMM, YYYY';
                    break;
                case appEnum.customDateFormats.Year:
                    dateFormat = 'YYYY';
                    break;
            }

            return dateFormat;
        }

        function createView(key, value) {
            return {
                label: key,
                value: value
            }
        }

        function getMainQuestionTemplate(index) {
            return {
                questionHeading: '<p>Please enter the question text here</p>',
                questionControlType: appEnum.questionControlTypes.gridMainQuestion.questionControlTypeId,
                questionSeqNum: null,
                config: {
                    messages: {
                        required: 'Please provide the answer for the question' + index
                    }   
                },
                controlList: [
                    { controlHeading: 'Yes' },
                    { controlHeading: 'No' }
                ]
            };
        }
    }
})();
