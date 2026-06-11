import React from "react";

import CategoryProductList from "./components/CategoryProductList";
import ProductList from "./components/ProductList";
import PostList from "./components/PostList";

import "./App.css";

function App() {
    return (
        <div>

            {/* ================= HEADER ================= */}

            <nav className="navbar navbar-expand-lg navbar-light bg-white shadow-sm py-3">

                <div className="container">

                    <a
                        className="navbar-brand d-flex align-items-center"
                        href="/"
                    >
                        <img
                            src="/Icon_Fullcolor.png"
                            alt="Tan3D"
                            style={{
                                height: "55px",
                                marginRight: "12px"
                            }}
                        />

                        <div>

                            <h4 className="mb-0 fw-bold text-dark">

                                Tan3D Printing Lab

                            </h4>

                            <small className="text-muted">

                                Máy in 3D & Vật liệu in

                            </small>

                        </div>

                    </a>

                    <div>

                        <button className="btn btn-outline-primary me-2">

                            Login

                        </button>

                        <button className="btn btn-primary">

                            Register

                        </button>

                    </div>

                </div>

            </nav>

            {/* ================= SLIDER ================= */}

            <div
                id="homeSlider"
                className="carousel slide"
                data-bs-ride="carousel"
                data-bs-interval="3000"
            >

                <div className="carousel-inner">

                    <div className="carousel-item active">

                        <img
                            src="https://www.crealityofficial.co.uk/files/html/20230919/Creality-UK-official-store-Ender-3-v3-ke-3d-printer-banner919.jpg"
                            className="d-block w-100"
                            alt=""
                            style={{
                                height: "450px",
                                objectFit: "cover"
                            }}
                        />

                    </div>

                    <div className="carousel-item">

                        <img
                            src="https://www.meme3d.com/wp-content/uploads/2024/06/dai-ly-may-in-3d-lon-nhat-hcm-web-1.webp"
                            className="d-block w-100"
                            alt=""
                            style={{
                                height: "450px",
                                objectFit: "cover"
                            }}
                        />

                    </div>

                </div>

            </div>

            {/* ================= CONTENT ================= */}

            <div className="container my-5">

                {/* CATEGORY */}

                <h2 className="text-center fw-bold mb-4">

                    Danh mục sản phẩm

                </h2>

                <CategoryProductList />

                {/* PRODUCT */}

                <div className="mt-5">

                    <h2 className="text-center fw-bold mb-4">

                        Sản phẩm nổi bật

                    </h2>

                    <ProductList />

                </div>

                {/* POST */}

                <div className="mt-5">

                    <h2 className="text-center fw-bold mb-4">

                        Tin tức & Hướng dẫn

                    </h2>

                    <PostList />

                </div>

            </div>

            {/* ================= FOOTER ================= */}

            <footer
                className="text-white mt-5"
                style={{
                    background: "#1d1d1d"
                }}
            >

                <div className="container py-5">

                    <div className="row">

                        <div className="col-md-4">

                            <img
                                src="/Icon_Fullcolor.png"
                                alt=""
                                style={{
                                    height: "60px"
                                }}
                            />

                            <h4 className="mt-3">

                                Tan3D Printing Lab

                            </h4>

                            <p className="text-light">

                                Chuyên cung cấp máy in 3D,
                                nhựa PLA, PETG, ABS,
                                phụ kiện và giải pháp in 3D.

                            </p>

                        </div>

                        <div className="col-md-4">

                            <h5>

                                Thông tin

                            </h5>

                            <ul className="list-unstyled">

                                <li>🏠 TP. Hồ Chí Minh</li>

                                <li>📧 tan3d@gmail.com</li>

                                <li>📞 0909 999 999</li>

                            </ul>

                        </div>

                        <div className="col-md-4">

                            <h5>

                                Người phát triển

                            </h5>

                            <p>

                                Tran Trong Tan

                            </p>

                            <p>

                                MSSV: 2123110006

                            </p>

                            <p>

                                ASP.NET Core MVC + ReactJS

                            </p>

                        </div>

                    </div>

                    <hr
                        style={{
                            background: "#666"
                        }}
                    />

                    <div className="text-center text-secondary">

                        © 2026 Tan3D Printing Lab.
                        All Rights Reserved.

                    </div>

                </div>

            </footer>

        </div>
    );
}

export default App;