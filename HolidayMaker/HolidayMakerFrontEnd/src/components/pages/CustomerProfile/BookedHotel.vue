<template>
  <div class="card mb-3">
    <!-- style="max-width: 540px;" (in style)-->
    <div class="row g-0">
      <div class="col-md-4">
        <img
          :src="hotel.hotelImg"
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
          <div v-if="hotel.status != 'Cancelled' && !canceled">
            <router-link :to="'/reservationDetails/' + hotel.reservationId">
                <Button id="buttonG" class="p-button-info mr-1" label="Order details"></Button>
            </router-link>
            <Button id="buttonG" @click="toggleEdit" class="p-button-info mr-1" label="Edit Booking"></Button>

            <Button  @click="cancel" class="p-button-danger" label="Cancel booking"></Button>
          </div>
          <div v-else>
            <p style="color: red">This booking is cancelled</p>
          </div>

        </div>
      </div>
    </div>
    <div v-if="edit">
      <ProfileCustomerDetails :hotel="hotel" />
    </div>
  </div>
</template>

<script>
import ProfileCustomerDetails from "/src/components/pages/CustomerProfile/ProfileCustomerDetails.vue";

import Button from "primevue/button";
export default {
  components: {
    ProfileCustomerDetails,
    Button,
  },
  props: {
    hotel: {},
  },
  data() {
    return {
      edit: false,
      canceled: false,
    };
  },
  computed: {
    startDate() {
      if(this.hotel.startDate === undefined){
        return 'Not available'
      }
      return this.hotel.startDate.split("T")[0];
    },
    endDate() {
      if(this.hotel.endDate === undefined){
        return 'Not available'
      }
      return this.hotel.endDate.split("T")[0];
    },
  },
  methods: {
    toggleEdit() {
      this.edit = !this.edit;
    },
    CancelBooking() {
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
          this.canceled = true;
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    },
    cancel() {
      this.$confirm.require({
        message: "Are you sure you want to cancel your booking?",
        header: "Confirmation",
        icon: "pi pi-exclamation-triangle",
        acceptClass: 'p-button-danger',
        accept: () => {
          //callback to execute when user confirms the action
          this.CancelBooking();
        },
        reject: () => {
          //callback to execute when user rejects the action
        },
      });
    },
  },
};
</script>

<style scoped>

#buttonG{
  background: #53c16e;
  border:#14a04d;
}

#buttonG:enabled:hover{
  background:#348047 !important;
  border-color:#14a04d;
}


</style>