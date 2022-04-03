using System.Collections.Generic;
using System.Security.Claims;

namespace Infrastructure.Security
{
    public class ClaimStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {

            new Claim("Officer","Officer"),
            new Claim("HeadDepartment","HeadDepartment"),
            new Claim("Read","Read"),
            new Claim("Details","Details"),
            new Claim("Search","Search"),
            new Claim("Create", "Create"),
            new Claim("Edit","Edit"),
            new Claim("Delete","Delete"),
            new Claim("Migrate","Migrate"),
            new Claim("UrgentFiles","UrgentFiles")
        };
    }
}
