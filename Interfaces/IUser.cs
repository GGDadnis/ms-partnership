using ms_partnership.Models.Entities.Dtos.User;

namespace ms_partnership.Interfaces
{
    public interface IUser : IBaseGuid<AddUserDto, ReadUserDto>, IUpdate<UpdateUserDto, ReadUserDto>
    {
        ReadUserDto LogicalRemove(Guid id);
    }
}