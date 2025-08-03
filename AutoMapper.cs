using AutoMapper;
namespace AutoMapperDemo
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                    //Configuring Employee and EmployeeDTO
                    cfg.CreateMap<Employee, EmployeeDTO>();
                    //Any Other Mapping Configuration ....
                });

            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

