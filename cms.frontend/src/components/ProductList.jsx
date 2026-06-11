import React, { useState, useEffect } from "react";
import productService from "../services/productService";

const ProductList = () => {

    const [products, setProducts] = useState([]);

    const [loading, setLoading] = useState(true);

    useEffect(() => {

        const fetchProducts = async () => {

            try {

                setLoading(true);

                const data =
                    await productService.getAllProducts();

                setProducts(data);

            }
            catch (error) {

                console.error(
                    "Lỗi khi tải sản phẩm:",
                    error
                );

            }
            finally {

                setLoading(false);

            }

        };

        fetchProducts();

    }, []);

    if (loading) {

        return (
            <div className="text-center my-4">

                Đang tải sản phẩm...

            </div>
        );

    }

    return (

        <div className="row">

            {
                products.length === 0

                    ?

                    (
                        <div className="col-12">

                            <p className="text-muted">

                                Chưa có sản phẩm.

                            </p>

                        </div>
                    )

                    :

                    (

                        products.map((item) => (

                            <div
                                className="col-md-6 mb-4"
                                key={item.id}
                            >

                                <div className="card shadow-sm h-100">

                                    {
                                        item.imageUrl &&

                                        <img
                                            src={`https://localhost:7009${item.imageUrl}`}
                                            className="card-img-top"
                                            alt={item.name}
                                            style={{
                                                height: "220px",
                                                objectFit: "cover"
                                            }}
                                        />

                                    }

                                    <div className="card-body">

                                        <h5 className="card-title">

                                            {item.name}

                                        </h5>

                                        <p className="text-danger fw-bold">

                                            {new Intl.NumberFormat(
                                                "vi-VN",
                                                {
                                                    style: "currency",
                                                    currency: "VND"
                                                }
                                            ).format(item.price)}

                                        </p>

                                        <p className="text-muted">

                                            Tồn kho:

                                            {" "}

                                            {item.stockQuantity}

                                        </p>

                                    </div>

                                    <div className="card-footer bg-white">

                                        <button className="btn btn-primary btn-sm w-100">

                                            <i className="fa-solid fa-eye me-2"></i>

                                            Xem chi tiết

                                        </button>

                                    </div>

                                </div>

                            </div>

                        ))

                    )

            }

        </div>

    );

};

export default ProductList;