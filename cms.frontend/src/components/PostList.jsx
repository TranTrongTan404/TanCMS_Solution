import React, { useEffect, useState } from "react";
import postService from "../services/postService";

const PostList = () => {

    const [posts, setPosts] = useState([]);

    const [loading, setLoading] = useState(true);

    useEffect(() => {

        const fetchPosts = async () => {

            try {

                const data = await postService.getAllPosts();

                // Chỉ lấy 3 bài mới nhất
                setPosts(data.slice(0, 3));

            }
            catch (error) {

                console.log(error);

            }
            finally {

                setLoading(false);

            }

        };

        fetchPosts();

    }, []);

    if (loading) {

        return <p>Đang tải bài viết...</p>;

    }

    return (

        <div className="mt-5">

            <h3 className="mb-4">

                Bài viết mới nhất

            </h3>

            <div className="row">

                {

                    posts.map(post => (

                        <div
                            className="col-md-4 mb-4"
                            key={post.id}
                        >

                            <div className="card h-100 shadow-sm">

                                {

                                    post.imageUrl &&

                                    <img
                                        src={`https://localhost:7009${post.imageUrl}`}
                                        className="card-img-top"
                                        alt={post.title}
                                        style={{
                                            height: "220px",
                                            objectFit: "cover"
                                        }}
                                    />

                                }

                                <div className="card-body">

                                    <h5>

                                        {post.title}

                                    </h5>

                                    <small className="text-muted">

                                        {new Date(
                                            post.createdDate
                                        ).toLocaleDateString("vi-VN")}

                                    </small>

                                </div>

                            </div>

                        </div>

                    ))

                }

            </div>

        </div>

    );

};

export default PostList;