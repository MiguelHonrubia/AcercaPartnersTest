import React, { Component } from "react";
import { getCarDetail } from "../actions/CarAction";
import { connect } from "react-redux";
import CarForm from "./CarForm";

class CarModal extends Component {
  render() {
    const { modalShow, close, carDetail, isNew } = this.props;
    return (
      <>
        <CarForm
          show={modalShow}
          onHide={() => close()}
          data={isNew ? null : carDetail}
        />
      </>
    );
  }
}

const mapStateToProps = (state) => ({
  carDetail: state.carDetail,
});

export default connect(mapStateToProps, { getCarDetail })(CarModal);
