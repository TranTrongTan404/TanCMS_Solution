import axiosClient from "../api/axiosClient";

const categoryProductService = {
    getAllCategoryProducts: () => {
        const url = "/CategoriesProductsApi";
        return axiosClient.get(url);
    }
};

export default categoryProductService;