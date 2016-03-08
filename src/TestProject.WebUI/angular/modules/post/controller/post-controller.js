postModule
    .controller('PostController', function ($scope, PostService, UserService, PostObjectComposer) {
        $scope.posts = PostService.getPosts();

        $scope.getPostById = function (postId) {
            return PostService.getPostById(postId);
        }

        $scope.addPost = function (content) {
            var postDto = {
                PostId: 0,
                UserId: UserService.getCurrentUser(),
                Content: content
            }

            return PostService.addPost(PostObjectComposer.generatePostObject(postDto));
        }
    });