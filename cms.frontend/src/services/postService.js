import axiosClient from "../api/axiosClient";

const postService = {

    // Lấy tất cả bài viết
    getAllPosts: () => {

        return axiosClient.get("/Posts");

    }

};

export default postService;