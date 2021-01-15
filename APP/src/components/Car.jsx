import React, { Component } from "react";
import { Container, Row, Col, Button } from "react-bootstrap";
import { removeCar } from "../actions/CarAction";
import { connect } from "react-redux";

class Car extends Component {
  deleteCar = (id) => {
    this.props.removeCar(id);
  };

  render() {
    const { data, carDetail } = this.props;
    return (
      <Container>
        <Row className="justify-content-md-center mt-2">
          <Col xs={12} md={1}>
            {data.orderNumber}
          </Col>
          <Col xs={12} md={1}>
            {data.frame}
          </Col>
          <Col xs={12} md={2}>
            {data.model}
          </Col>
          <Col xs={12} md={2}>
            {data.enrollment}
          </Col>
          <Col xs={12} md={3}>
            {data.deadline}
          </Col>
          <Col xs={12} md={3}>
            <Container>
              <Row className="justify-content-md-center">
                <Col xs={6} sm={6}>
                  <Button variant="primary" onClick={() => carDetail(data.id)}>
                    editar
                  </Button>
                </Col>
                <Col xs={6} sm={6}>
                  <Button
                    variant="secondary"
                    onClick={() => this.deleteCar(data.id)}
                  >
                    eliminar
                  </Button>
                </Col>
              </Row>
            </Container>
          </Col>
        </Row>
      </Container>
    );
  }
}

export default connect(null, { removeCar })(Car);
