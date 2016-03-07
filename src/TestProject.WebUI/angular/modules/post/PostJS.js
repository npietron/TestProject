var postModule = angular.module('post', ['app.config']);
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
postModule
    .factory('PostObjectComposer', function () {

        return {
            generatePostObject: generatePostObject
        };

        function generatePostObject(data) {
            return {
                Request: {
                    PostId: data.UserId,
                    Content: data.Content
                }
            }
        }

    });
postModule
    .controller('PostController', function ($scope, PostService, PostObjectComposer) {
        $scope.posts = PostService.getPosts();

        $scope.getPostById = function (postId) {
            return PostService.getPostById(postId);
        }

        $scope.addPost = function (content) {
            var postDto = {
                PostId: 0,
                Content: content
            }

            return PostService.addPost(PostObjectComposer.generatePostObject(postDto));
        }
    });