using EticaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {

        readonly UserManager<EticaretAPI.Domain.Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<EticaretAPI.Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
          IdentityResult identityResult= await  _userManager.CreateAsync(new()
            {
                UserName = request.Username,
                Email=request.Email,
                NameSurname=request.NameSurname,

            },request.Password) ;
            CreateUserCommandResponse response = new CreateUserCommandResponse() { Succeeded = identityResult.Succeeded };

            if (identityResult.Succeeded)
            {
                response.Message = "Kullanıcı Başarlı Şekilde Oluşturuldu";

            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    response.Message += $"{error.Code}-{error.Description}<br>";
                }
                return response;
             

            }



        }
    }
}
