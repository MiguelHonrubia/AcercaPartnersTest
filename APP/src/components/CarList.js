import React, { Component } from "react";
import { Container, Row, Button } from "react-bootstrap";
import { connect } from "react-redux";
import { getCarList, getCarDetail } from "../actions/CarAction";
import Car from "./Car.jsx";
import CarModal from "./CarModal";

class CarList extends Component {
  state = {
    modalShow: false,
    isNew: false,
  };

  componentDidMount() {
    this.props.getCarList();
  }

  newCar = async () => {
    this.setState({
      modalShow: true,
      isNew: true,
    });
  };

  closeModal = async () => {
    this.setState({
      modalShow: false,
    });
  };

  carDetail = async (id) => {
    await this.props.getCarDetail(id);
    this.setState({
      modalShow: true,
      isNew: false,
    });
  };

  render() {
    const { cars } = this.props;
    return (
      <>
        <Container>
          <Row className="justify-content-md-center">
            <h2>Listado de coches</h2>
          </Row>
          <Row>
            <Container>
              <Row className="my-2">
                <Button variant="primary" onClick={() => this.newCar()}>
                  Añadir coche
                </Button>
              </Row>
              <Row className="justify-content-md-center my-2">
                <ul>
                  {cars.map((car, index) => (
                    <Car
                      data={car}
                      key={index}
                      isNew={this.state.isNew}
                      carDetail={this.carDetail}
                    />
                  ))}
                </ul>
              </Row>
            </Container>
          </Row>
        </Container>
        <CarModal modalShow={this.state.modalShow} close={this.closeModal} />
      </>
    );
  }
}

// state
const mapStateToProps = (state) => ({
  cars: state.cars,
});

export default connect(mapStateToProps, { getCarList, getCarDetail })(CarList);
