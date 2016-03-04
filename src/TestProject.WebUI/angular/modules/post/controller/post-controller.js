postModule
    .controller('PostController', function ($scope, PostService) {
        $scope.posts = PostService.getPosts();

        $scope.getPostById = function (postId) {
            return PostService.getPostById(postId);
        }

        $scope.addPost = function (postDto) {
            return PostService.addPost(postDto);
        }
    });