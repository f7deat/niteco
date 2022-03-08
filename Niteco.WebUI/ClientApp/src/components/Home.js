import React, { Component, useEffect, useState } from 'react';
import axios from 'axios';

export const Home = () => {
    const [orders, setOrders] = useState();
    useEffect(() => {
        axios.get('/api/all-orders').then(response => {
            setOrders(response.data);
        });
    }, [])
    return (
        <div>
            <div className="d-flex gap-4">
                <input className="form-control" type="text" placeholder="Input keyword..." />
                <button className="btn btn-primary" type="button">Search</button>
            </div>
        </div>
    );
}
