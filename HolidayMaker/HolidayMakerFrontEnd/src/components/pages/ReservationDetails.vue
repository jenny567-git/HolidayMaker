<template>
  <div>
    <h1>Order details</h1>
        <div class="row">
            <div class="col">
                <Card style="">
                    <template #title>
                    Personal Details
                    </template>
                    <template #content>
                        <ul class="list-group list-group-flush" >
                            <li class="list-group-item leftTexAlignt"> <b>Full name:</b> {{reservationInfo.fullName}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Email:</b> {{reservationInfo.guestDetails.email}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Phone:</b> {{reservationInfo.guestDetails.phoneNumber}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Address:</b> {{reservationInfo.guestDetails.street}}, {{reservationInfo.guestDetails.zipCode}}, {{reservationInfo.guestDetails.city}}</li>
                        </ul>
                    </template>
                </Card>
            </div>
            <div class="col">
                <Card style="">
                    <template #title>
                    Booking Details
                    </template>
                    <template #content>
                        <ul class="list-group list-group-flush" >
                            <li class="list-group-item leftTexAlignt"> <b>Hotel name:</b> {{reservationInfo.hotelName}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Check in:</b> {{checkInDate}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Check out:</b> {{checkOutDate}}</li>
                            <li v-if="reservationInfo.children > 0" class="list-group-item leftTexAlignt"> <b>Number of people:</b> {{reservationInfo.adults}} adults, {{reservationInfo.children}} children</li>
                            <li v-else class="list-group-item leftTexAlignt"> <b>Number of people:</b> {{reservationInfo.adults}} adults</li>
                            <li class="list-group-item leftTexAlignt"> <b>Service type:</b> {{reservationInfo.type}}</li>
                            <li v-if="reservationInfo.extraBed" class="list-group-item leftTexAlignt"> <b>Extra bed:</b> Yes</li>
                            <li class="list-group-item leftTexAlignt"> <b>Total price:</b> {{reservationInfo.totalPrice}} SEK</li>
                        </ul>
                    </template>
                </Card>
            </div>
        </div>
  </div>
</template>

<script>
import Card from 'primevue/card'

export default {
  components: {
    Card,
  },
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
        guestDetails:{
          email: '',
          phoneNumber: '',
          street: '',
          city: '',
          zipCode: '',
        }
      },
    };
  },
  computed: {
    reservation() {
      return this.$store.state.reservation;
    },
    checkInDate() {
      if(this.reservationInfo.startDate === ''){
        return "not found";
      }else{
        return this.reservationInfo.startDate.split("T")[0];
      }
    },
    checkOutDate() {
      if(this.reservationInfo.endDate === ''){
        return "not found";
      }else{
        return this.reservationInfo.endDate.split("T")[0];
      }
    },
  },
  created() {
    this.$store
      .dispatch("getReservationById", this.$route.params.id)
      .then(() => {
        this.reservationInfo = this.$store.state.reservation;
        console.log(this.reservationInfo.startDate)
      });
  },
};
</script>
