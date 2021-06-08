<template>
  <div id="test2">
    <br />
    <div class="container-fluid">
      <h3>Success!</h3>
      <p><strong>Name: </strong> {{ reservationInfo.fullName }}</p>
      <p><strong>Hotel: </strong>{{ reservationInfo.hotelName }}</p>
      <p><strong>Checkin: </strong>{{ checkInDate }}</p>
      <p><strong>Checkout: </strong>{{ checkOutDate }}</p>
      <h3>Booked rooms</h3>

      <p>
        <strong>Single rooms:</strong>
        {{ reservationInfo.hotelRoomsViewModel.singleRooms }}
      </p>
      <p>
        <strong>Double rooms: </strong>
        {{ reservationInfo.hotelRoomsViewModel.doubleRooms }}
      </p>
      <p>
        <strong>Family rooms: </strong>
        {{ reservationInfo.hotelRoomsViewModel.familyRooms }}
      </p>
      <h3>Persons</h3>
      <p>
        <strong>Adults: {{ reservationInfo.adults }}</strong>
      </p>
      <p>
        <strong>Children: {{ reservationInfo.children }}</strong>
      </p>
      <p><strong>Message to hotel: </strong></p>
      <p>{{ reservationInfo.customerMessage }}</p>
      <p><strong>Accomodation type: </strong> {{ reservationInfo.type }}</p>
      <p v-if="reservationInfo.extraBed"><strong>Extra bed:</strong> Yes</p>
      <p><strong>Price: </strong>{{ reservationInfo.totalPrice }}</p>
    </div>
  </div>
</template>

<script>
export default {
  components: {},
  data() {
    return {
      reservationInfo: {
        fullName: "",
        hotelName: "",
        startDate: "",
        endDate: "",
        adults: "",
        children: "",
        customerMessage: "",
        type: "",
        totalPrice: "",
        extraBed:false,
        hotelRoomsViewModel: {
          singleRooms: "2",
          doubleRooms: "2",
          familyRooms: "2",
        },
      },
    };
  },
  computed: {
    reservation() {
      return this.$store.state.reservation;
    },
    checkInDate() {
      return this.reservationInfo.startDate.split("T")[0];
    },
    checkOutDate() {
      return this.reservationInfo.endDate.split("T")[0];
    },
  },
  created() {
    this.$store
      .dispatch("getReservationById", this.$route.params.id)
      .then(() => {
        this.reservationInfo = this.$store.state.reservation;
      });
  },
};
</script>
