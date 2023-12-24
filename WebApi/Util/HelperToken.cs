using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace WebApi.Util
{
    public class HelperToken
    {
        public static ClaimTokenData LeerToken(IPrincipal principal)
        {
            var response = new ClaimTokenData();
            try
            {
                ClaimsPrincipal claimsToken = principal as ClaimsPrincipal;
                var clames = claimsToken.Claims.ToList();
                foreach (var item in clames)
                {
                    if (item.Subject.IsAuthenticated == true)
                    {
                        response.cedula = item.Value;
                        response.codigo = 1;
                    }
                }

            }
            catch (Exception)
            {
                response.codigo = 0;
            }
            return response;
        }
    }
}