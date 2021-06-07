<template>
    <div>
        <BookedHotel v-for="hotel in bookedHotels" :hotel="hotel" :key="hotel.reservationId"></BookedHotel>
        <ConfirmDialog></ConfirmDialog>
    </div>
</template>
<script>
import BookedHotel from './BookedHotel.vue'
import ConfirmDialog from "primevue/confirmdialog";
export default {
    components:{
        BookedHotel,
        ConfirmDialog
    },
    created(){
        // Get booked hotels
        this.$store.dispatch('getBookings');
        console.log(this.$store.state.bookedHotels)
    },
    computed:{
        bookedHotels(){
            return this.$store.state.bookedHotels;
        }
    }
}
</script>
<style lang="">
    
</style>