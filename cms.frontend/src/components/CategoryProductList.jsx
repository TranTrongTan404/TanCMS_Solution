import React, { useState, useEffect } from "react";
import categoryProductService from "../services/categoryProductService";

const CategoryProductList = () => {
    const [categoryProducts, setCategoryProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {

        const fetchCategoryProducts = async () => {

            try {

                setLoading(true);

                const data =
                    await categoryProductService.getAllCategoryProducts();

                setCategoryProducts(data);

            } catch (error) {

                console.error(
                    "Lỗi khi tải danh mục sản phẩm:",
                    error
                );

            } finally {

                setLoading(false);

            }

        };

        fetchCategoryProducts();

    }, []);

    if (loading) {

        return (

            <div className="text-center my-4">

                Đang tải danh mục sản phẩm...

            </div>

        );

    }

    return (

        <div className="container">

            {
                categoryProducts.length === 0

                    ?

                    (

                        <div className="text-center text-muted py-4">

                            Không có danh mục nào.

                        </div>

                    )

                    :

                    (

                        <div
                            className="d-flex flex-wrap justify-content-center align-items-center"
                            style={{
                                gap: "15px"
                            }}
                        >

                            {

                                categoryProducts.map((item) => (

                                    <button
                                        key={item.id}
                                        type="button"
                                        className="btn shadow-sm border"
                                        style={{
                                            minWidth: "180px",
                                            height: "60px",
                                            borderRadius: "40px",
                                            background: "#ffffff",
                                            color: "#333",
                                            fontWeight: "600",
                                            transition: "all .3s"
                                        }}
                                        onMouseEnter={(e) => {

                                            e.currentTarget.style.background =
                                                "#0d6efd";

                                            e.currentTarget.style.color =
                                                "#ffffff";

                                            e.currentTarget.style.transform =
                                                "translateY(-4px)";

                                        }}
                                        onMouseLeave={(e) => {

                                            e.currentTarget.style.background =
                                                "#ffffff";

                                            e.currentTarget.style.color =
                                                "#333";

                                            e.currentTarget.style.transform =
                                                "translateY(0)";

                                        }}
                                    >

                                        <i className="fa-solid fa-cube me-2"></i>

                                        {item.name}

                                    </button>

                                ))

                            }

                        </div>

                    )

            }

        </div>

    );

};

export default CategoryProductList;