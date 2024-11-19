using AutoMapper;
using LibraryCrud.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCrud.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //defino un controlador base que me va a dar acceso a las dependencias que necesito
    public class BaseApiController: ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public BaseApiController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
