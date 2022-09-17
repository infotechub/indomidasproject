using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class InMemoryConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
          new List<IdentityResource>
          {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile(),
          new IdentityResources.Address(),
          new IdentityResource("roles", "User role(s)", new List<string> { "role" }),
          new IdentityResource("position", "Your Position", new List<string> { "position" }),
           new IdentityResource("country", "Your Country", new List<string> { "country" })
          };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new ApiScope[]
            {
              new ApiScope("complainApi.read"),
              new ApiScope("complainApi.write"),

            };

        //new List<ApiScope> { new ApiScope("complainApi", "Complain API") };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new ApiResource[]
            {
               new ApiResource("complainApi")
              {
               Scopes = new List<string>{ "complainApi.read","complainApi.write" },
               ApiSecrets = new List<Secret>{ new Secret("fintraksecret".Sha256()) }
              }
            };
        // new List<ApiResource>
        // {
        //new ApiResource("complainApi", "Complain API")
        //{
        //    Scopes = { "complainApi" }
        //}
        // };

        public static List<TestUser> GetUsers() =>
            new List<TestUser>
            {
           new TestUser
            {
                 SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                 Username = "freempire",
                 Password = "Pass123@",
                 Claims = new List<Claim>
                 {
                   new Claim("given_name", "Akin"),
                   new Claim("family_name", "Bamidele"),
                   new Claim("address", "Lagos Nigeria"),
                   new Claim("role", "Admin"),
                   new Claim("position", "Administrator"),
                   new Claim("country", "Nigeria")
                 }
            },
           new TestUser
            {
               SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
               Username = "Testme",
               Password = "Pass123@",
               Claims = new List<Claim>
               {
                 new Claim("given_name", "Victor"),
                 new Claim("family_name", "Alex"),
                 new Claim("address", "Lagos Nigeria"),
                 new Claim("role", "Visitor"),
                 new Claim("position", "Viewer"),
                 new Claim("country", "Nigeria")
               }
            }
           };

           public static IEnumerable<Client> GetClients() =>

             new Client[]
             {
                
               new Client
               {
                  ClientId = "fintrak",
                  ClientName = "Client Credentials Client",
                  AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                  ClientSecrets = { new Secret("fintraksecret".Sha256()) },
                  AllowedScopes = 
                   { 
                       IdentityServerConstants.StandardScopes.OpenId, "complainApi.read",
                       IdentityServerConstants.StandardScopes.Address,
                       "roles"


                   }
               },
               new Client
               {
                   ClientName = "MVC Client",
                   ClientId = "mvc-client",
                   AllowedGrantTypes = GrantTypes.Hybrid,
                   RedirectUris = new List<string>{ "https://localhost:5008/signin-oidc" },
                   RequirePkce = false,
                   AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.Address, "roles", "complainApi.read", "position","country" },
                   ClientSecrets = { new Secret("MVCSecret".Sha512()) },
                   PostLogoutRedirectUris = new List<string> { "https://localhost:5008/signout-callback-oidc" },
                   RequireConsent = true
               }
             };


        //new List<Client>
        //{
        //  new Client
        //  {
        //  ClientId = "fintrak",
        //  ClientSecrets = new [] { new Secret("fintraksecret".Sha512()) },
        //  AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
        //   AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, "complainApi" }
        //  }
        //};
    }
}
