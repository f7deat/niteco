import React, { Component, useEffect, useState } from 'react';
import axios from 'axios';

export const Home = () => {

    const [orders, setOrders] = useState([]);
    const [products, setProducts] = useState([]);
    const [customers, setCustomers] = useState([]);

    const [pageIndex, setPageIndex] = useState(1)
    const [pageSize, setPageSize] = useState(10)
    const [total, setTotal] = useState(0)

    const [show, setShow] = useState(false);

    // Message Error
    const [errorMessage, setErrorMessage] = useState('')

    // keyword for search
    const [searchTerm, setSearchTerm] = useState('')

    // data
    const [orderName, setOrderName] = useState('');
    const [product, setProduct] = useState('');
    const [customer, setCustomer] = useState('')
    const [orderDate, setOrderDate] = useState()
    const [amount, setAmount] = useState(0)

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    useEffect(() => {
        featchData();
        // Get all Product
        axios.get(`/api/product/all`).then(response => {
            setProducts(response.data)
        })
        // Get all Customer
        axios.get(`/api/customer/all`).then(response => {
            setCustomers(response.data)
        })
    }, [])

    // binding data to grid
    const featchData = () => {
        axios.get(`/api/all-orders?searchTerm=${searchTerm}&pageIndex=${pageSize}&pageSize=${pageSize}`).then(response => {
            if (response.data.succeeded) {
                setOrders(response.data.data);
                setPageIndex(response.data.pageIndex);
                setPageSize(response.data.pageSize);
                setTotal(response.data.total);
            }
        });
    }

    // Pagingination
    const generatePagging = () => {
        let items = [];
        for (let number = 1; number <= total; number++) {
            items.push(
                <Pagination.Item key={number} active={number === pageIndex}>
                    {number}
                </Pagination.Item>,
            );
        }
        return items
    }

    // hanlde cretae new order
    const handleFinish = () => {
        // todo: validate
        if (!orderName) {
            return setErrorMessage('Please input customer name')
        }
        // send request to create new order
        axios.post('/order/add', {
            orderName,
            product,
            customer,
            orderDate,
            amount,
        }).then(response => {
            if (response.data.succeeded) {
                // reload data grid
                featchData();
                // Close modal
                handleClose();
            }
        })
    }

    return (
        <div>
            <div className="d-flex gap-4 mb-4">
                <input className="form-control" type="text" placeholder="Input keyword..." onChange={(e) => setSearchTerm(e.target.value)} />
                <button className="btn btn-primary" type="button">Search</button>
            </div>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Product Name</th>
                        <th>Category Name</th>
                        <th>Customer Name</th>
                        <th>Order Date</th>
                        <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        orders && orders.map(order => (
                            <tr key={order.id}>
                                <td>{order.productName}</td>
                                <td>{order.categoryName}</td>
                                <td>{order.customerName}</td>
                                <td>{order.orderDate}</td>
                                <td>{order.amount}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>

            <Pagination>
                {generatePagging()}
            </Pagination>

            <div className="py-4 text-right">
                <button className="btn btn-primary" onClick={handleShow}>Create new order</button>
            </div>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Create new order</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Alert variant='danger'>
                        {errorMessage}
                    </Alert>
                    <div>Order name</div>
                    <input className="form-control mb-2" onChange={(e) => setOrderName(e.target.value)}/>
                    <div>Product</div>
                    <select onChange={(e) => setProduct(e.target.value)} className="form-control mb-2">
                        {
                            products && products.map(x => (
                                <option value={x.id}>{x.name}</option>
                            ))
                        }
                    </select>
                    <div>Customer</div>
                    <select onChange={(e) => setCustomer(e.target.value)} className="form-control mb-2">
                        {
                            customers && customers.map(x => (
                                <option value={x.id}>{x.name}</option>
                            ))
                        }
                    </select>
                    <div>Order date</div>
                    <input className="form-control mb-2" onChange={e => setOrderDate(e.target.value)} />
                    <div>Amount</div>
                    <input className="form-control mb-2" onChange={e => setAmount(e.target.value)} />
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleFinish}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
}
