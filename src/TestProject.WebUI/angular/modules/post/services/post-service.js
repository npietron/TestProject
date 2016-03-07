postModule.
    factory('PostService', function (apiPathConfig, Restangular) {
        var addPostService = Restangular.all(apiPathConfig.addPost);

        return {
            addPost: addPost,
            getPostById: getPostById,
            getPosts: getPosts,
            getPostsByUserId: getPostsByUserId
        };

        function addPost(data) {
            return addPostService.post(data);
        }

        function getPosts() {
            var posts = Restangular.one(apiPathConfig.posts);
            return posts.get();
        }

        function getPostById(id) {
            var posts = Restangular.one(apiPathConfig.postsById + '(PostId=' + id + ')');
            return posts.get();
        }

        function getPostsByUserId(id) {
            var posts = Restangular.one(apiPathConfig.postsByUserId + '(UserId=' + id + ')');
            return posts.get();
        }

    });