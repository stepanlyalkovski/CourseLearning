using System.Threading.Tasks;
using CourseLearning.Application.Interface;
using CourseLearning.Application.Mapper;
using CourseLearning.DAL.Interface;
using CourseLearning.Model;
using CourseLearning.Model.DTO;

namespace CourseLearning.Application
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        private DtoMapper<User, UserDTO> _userMapper = new DtoMapper<User, UserDTO>();

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(UserDTO userDto)
        {
            var user = _userMapper.ToEntity(userDto);
            _unitOfWork.Users.Add(user);
            await _unitOfWork.CompleteAsync();
            return user.UserId;
        }

        public Task<UserDTO> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(UserDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(UserDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDTO> Get(string email)
        {
            var user = await _unitOfWork.Users.GetAsync(email);
            return _userMapper.ToEntityDTO(user);
        }
    }
}