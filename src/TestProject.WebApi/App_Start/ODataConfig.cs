using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using TestProject.Services.Contracts.Message;
using TestProject.Services.Contracts.Post;
using TestProject.Services.Contracts.User;

namespace TestProject.WebApi
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("ODataRoute", "api", CreateEdmModel());
        }

        private static IEdmModel CreateEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<MessageDto>("Message");
            builder.EntitySet<UserDto>("User");
            builder.EntitySet<PostDto>("Post");

            SetKeys(builder);
            BuildActions(builder);
            BuildFunctions(builder);

            return builder.GetEdmModel();
        }

        private static void SetKeys(ODataModelBuilder builder)
        {
            builder.EntityType<UserDto>().HasKey(r => new { r.UserId });
            builder.EntityType<PostDto>().HasKey(r => new { r.PostId });
            builder.EntityType<MessageDto>().HasKey(r => new { r.MessageId });
        }

        private static void BuildFunctions(ODataModelBuilder builder)
        {
            #region Users

            builder.Function("GetUser")
                .ReturnsFromEntitySet<UserDto>("User")
                .Parameter<string>("UserId");

            #endregion

            #region Posts

            builder.Function("GetPostsByUser")
                .ReturnsCollectionFromEntitySet<PostDto>("Post")
                .Parameter<string>("UserId");

            #endregion

            #region Messages

            builder.Function("GetMessagesByUser")
                .ReturnsCollectionFromEntitySet<MessageDto>("Message")
                .Parameter<string>("UserId");

            builder.Function("GetMessagesByPost")
                .ReturnsCollectionFromEntitySet<MessageDto>("Message")
                .Parameter<string>("PostId");

            #endregion

        }

        private static void BuildActions(ODataModelBuilder builder)
        {
            #region Users

            ActionConfiguration actionAddUser = builder.Action("AddUser");

            actionAddUser.Parameter<UserDto>("Request");
            actionAddUser.ReturnsCollectionFromEntitySet<UserDto>("User");

            #endregion

            #region Posts

            ActionConfiguration actionAddPost = builder.Action("AddPost");

            actionAddPost.Parameter<PostDto>("Request");
            actionAddPost.ReturnsCollectionFromEntitySet<PostDto>("Post");

            #endregion

            #region Messages

            ActionConfiguration actionAddMessage = builder.Action("AddMessage");

            actionAddMessage.Parameter<MessageDto>("Request");
            actionAddMessage.ReturnsCollectionFromEntitySet<MessageDto>("Message");

            #endregion
        }
    }
}