import axiosClient from "../api/axiosClient";

const productService = {
    // Lấy toàn bộ sản phẩm
    getAllProducts: () => {
        const url = "/ProductsApi";
        return axiosClient.get(url);
    }
};

export default productService;