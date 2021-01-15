import React, { Component } from "react";
import { Modal, Button, Container, Row, Col } from "react-bootstrap";
import { addCar, editCar } from "../actions/CarAction";
import { connect } from "react-redux";

class CarForm extends Component {
  state = {
    id: 0,
    orderNumber: 0,
    frame: String.Empty,
    model: String.Empty,
    enrollment: String.Empty,
    deadline: String.Empty,
  };

  onSubmit = (values) => {
    try {
      if (this.state.id === undefined || this.state.id === null) {
        this.props.addCar(this.state);
      } else {
        this.props.editCar(this.state);
      }
    } catch {
      alert("error");
    }
  };

  componentWillReceiveProps(nextProps, nextState) {
    const {
      id,
      orderNumber,
      frame,
      model,
      enrollment,
      deadline,
    } = nextProps.data;

    this.setState({
      id: id,
      orderNumber: Number(orderNumber),
      frame: frame,
      model: model,
      enrollment: enrollment,
      deadline: deadline,
    });
  }

  id = (e) => {
    this.setState({ id: Number(e.target.value) });
  };

  orderNumber = (e) => {
    this.setState({ orderNumber: Number(e.target.value) });
  };

  frame = (e) => {
    this.setState({ frame: e.target.value });
  };

  model = (e) => {
    this.setState({ model: e.target.value });
  };

  enrollment = (e) => {
    this.setState({ enrollment: e.target.value });
  };

  deadline = (e) => {
    this.setState({ deadline: e.target.value });
  };

  render() {
    return (
      <Modal
        {...this.props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <form onSubmit={(values) => this.onSubmit(values)}>
          <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">
              {this.state.id != undefined ? "Editar coche" : "Nuevo coche"}
            </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Container>
              <Row className="mt-2">
                <Col>
                  <label>Número de pedido</label>
                  <input
                    onChange={this.orderNumber}
                    type="number"
                    className="form-control"
                    placeholder="número de pedido"
                    value={this.state.orderNumber}
                  />
                </Col>
                <Col>
                  <label>Bastidor</label>
                  <input
                    onChange={this.frame}
                    type="text"
                    className="form-control"
                    placeholder="bastidor"
                    value={this.state.frame}
                  />
                </Col>
              </Row>
              <Row className="mt-2">
                <Col>
                  <label>Modelo</label>
                  <input
                    onChange={this.model}
                    type="text"
                    className="form-control"
                    placeholder="modelo"
                    value={this.state.model}
                  />
                </Col>
                <Col>
                  <label>Matrícula</label>
                  <input
                    onChange={this.enrollment}
                    type="text"
                    className="form-control"
                    placeholder="matrícula"
                    value={this.state.enrollment}
                  />
                </Col>
              </Row>

              <Row className="mt-2">
                <Col>
                  <label>Fecha de entrega</label>
                  <input
                    onChange={this.deadline}
                    type="date"
                    className="form-control"
                    placeholder="fecha de entrega"
                    value={this.state.deadline}
                  />
                </Col>
                <Col>
                  <input
                    onChange={this.id}
                    type="number"
                    className="form-control"
                    placeholder="id"
                    value={this.state.id}
                    hidden={true}
                  />
                </Col>
              </Row>
            </Container>
          </Modal.Body>
          <Modal.Footer>
            <Button type="submit">Guardar</Button>
          </Modal.Footer>
        </form>
      </Modal>
    );
  }
}

export default connect(null, { addCar, editCar })(CarForm);
