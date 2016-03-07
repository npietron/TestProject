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