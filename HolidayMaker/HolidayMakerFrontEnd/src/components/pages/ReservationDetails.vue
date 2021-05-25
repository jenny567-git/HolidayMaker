<template>
  <br />
  <div>
    <div class="container-fluid">
      <p><strong>Name: </strong> {{ reservation.fullName }}</p>
      <p><strong>Hotel: </strong>{{ reservation.hotelName }}</p>
      <p><strong>Checkin: </strong>{{ reservation.startDate }}</p>
      <p><strong>Checkout: </strong>{{ reservation.endDate }}</p>
      <h3>Booked rooms</h3>

      <p>
        <strong>Single rooms:</strong>
        {{ reservation.hotelRoomsViewModel.singleRooms }}
      </p>
      <p>
        <strong>Double rooms: </strong>
        {{ reservation.hotelRoomsViewModel.doubleRooms }}
      </p>
      <p>
        <strong>Family rooms: </strong>
        {{ reservation.hotelRoomsViewModel.familyRooms }}
      </p>
      <h3>Persons</h3>
      <p>
        <strong>Adults: {{ reservation.adults }}</strong>
      </p>
      <p>
        <strong>Children: {{ reservation.children }}</strong>
      </p>
      <p><strong>Message to hotel: </strong></p>
      <p>{{ reservation.customerMessage }}</p>
      <p><strong>Accomodation type: </strong> {{ reservation.type }}</p>
      <p><strong>Price: </strong>{{ reservation.totalPrice }}</p>
    </div>
  </div>
</template>

<script>
export default {
  components: {},
  data() {
    return {
      reservationInfo: {},
    };
  },
  computed: {
    reservation() {
      return this.$store.state.reservation;
    },
  },
  created() {
    this.$store.dispatch("getReservationById", this.$route.params.id);
  },
};
</script>
