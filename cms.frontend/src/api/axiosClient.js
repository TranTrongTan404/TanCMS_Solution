import axios from "axios";

// Khởi tạo Axios với cấu hình chung
const axiosClient = axios.create({
    baseURL: "https://localhost:7009/api", // Đổi đúng port Backend
    headers: {
        "Content-Type": "application/json",
    },
    timeout: 10000,
});

// Interceptor xử lý phản hồi
axiosClient.interceptors.response.use(
    (response) => {
        // Chỉ trả về phần data
        return response.data;
    },
    (error) => {
        console.error("Lỗi kết nối API:", error.message);

        return Promise.reject(error);
    }
);

export default axiosClient;