<template>
  <div class="card mb-3">
    <!-- style="max-width: 540px;" (in style)-->
    <div class="row g-0">
      <div class="col-md-4">
        <img
          src="https://image.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg"
          alt="..."
          class="img-fluid"
        />
      </div>
      <div class="col-md-8">
        <div class="card-body">
          <h5 class="card-title">{{ hotel.hotelName }}</h5>
          <div class="textB">
            <p>{{ hotel.fullName }}</p>
            <p>{{ startDate }} - {{ endDate }}</p>
            <p>More information about the booking</p>
          </div>
          <!-- Button trigger modal -->
          <div v-if="hotel.status != 'Cancelled'">
            <button
              type="button"
              class="btn btn-danger float-end"
              data-bs-toggle="modal"
              data-bs-target="#staticBackdrop"
            >
              Cancel Booking
            </button>
            <button type="button" class="btn btn-info" @click="toggleEdit">
              Edit Booking
            </button>
          </div>
          <div v-else>
            <p style="color:red">This booking is cancelled</p>
          </div>

          <!-- Modal -->
          <div
            class="modal fade"
            id="staticBackdrop"
            data-bs-backdrop="static"
            data-bs-keyboard="false"
            tabindex="-1"
            aria-labelledby="staticBackdropLabel"
            aria-hidden="true"
          >
            <div class="modal-dialog">
              <div class="modal-content">
                <div class="modal-header">
                  <h5 class="modal-title" id="staticBackdropLabel">Warning</h5>
                  <button
                    type="button"
                    class="btn-close"
                    data-bs-dismiss="modal"
                    aria-label="Close"
                  ></button>
                </div>
                <div class="modal-body">
                  Are you sure you wish to cancel your booking?
                </div>
                <div class="modal-footer">
                  <button
                    type="button"
                    class="btn btn-secondary"
                    data-bs-dismiss="modal"
                  >
                    No
                  </button>
                  <button
                    type="button"
                    class="btn btn-danger"
                    @click="CancelBooking"
                  >
                    Yes
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div v-if="edit">
      <CustomerDetails />
    </div>
  </div>
</template>

<script>
import CustomerDetails from "/src/components/pages/CheckoutViewComponents/CustomerDetails.vue";

export default {
  components: {
    CustomerDetails,
  },
  props: {
    hotel: {},
  },
  data() {
    return {
      edit: false,
    };
  },
  computed: {
    startDate() {
      return this.hotel.startDate.split("T")[0];
    },
    endDate() {
      return this.hotel.endDate.split("T")[0];
    },
  },
  methods: {
    toggleEdit() {
      this.edit = !this.edit;
      this.$store.dispatch(
        "saveCustomerDetailsCheckout",
        this.hotel.guestDetails
      );
    },
    CancelBooking() {
      // console.log(this.hotel.reservationId)
      fetch(
        "https://localhost:44356/api/Booking/CancelBooking?id=" +
          this.hotel.reservationId,
        {
          method: "PUT",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(this.hotel.reservationId),
        }
      )
        .then((response) => response.json())
        .then((data) => {
          console.log("Success:", data);
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    },
  },
};
</script>