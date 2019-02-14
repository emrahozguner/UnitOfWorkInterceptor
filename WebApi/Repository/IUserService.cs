using AutoMapper;
using WebApi.Entity;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IUserService : IApiService
    {
        void AddNewUser(AddNewUserRequest reqModel);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;

        public UserService(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public void AddNewUser(AddNewUserRequest reqModel)
        {
            var user = MapToUser(reqModel);
            var userId = _userRepository.Insert(user);

            var address = MapToAddress(reqModel);
            address.UserId = userId;
            _addressRepository.Insert(address);
        }

        public User MapToUser(AddNewUserRequest reqModel)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AddNewUserRequest, User>(); });
            var iMapper = config.CreateMapper();
            return iMapper.Map<AddNewUserRequest, User>(reqModel, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.Name = src.User.Name;
                    dest.SurName = src.User.SurName;
                });
            });
        }

        public Address MapToAddress(AddNewUserRequest reqModel)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AddNewUserRequest, Address>(); });
            var iMapper = config.CreateMapper();
            return iMapper.Map<AddNewUserRequest, Address>(reqModel, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.CityCode = src.Address.CityCode;
                    dest.Description = src.Address.Description;
                    dest.DistrictCode = src.Address.DistrictCode;
                });
            });
        }
    }
}