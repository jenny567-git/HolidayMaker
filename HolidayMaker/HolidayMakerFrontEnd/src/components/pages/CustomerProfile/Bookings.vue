<template>
    <div>
        <div v-if="!bookedHotels.length && !errorText">
            <ProgressSpinner />
        </div>
        <div v-if="errorText">
            <p>No bookings have been loaded. Try refreshing or create a booking for them to show up here!</p>
        </div>
        <BookedHotel v-for="hotel in bookedHotels" :hotel="hotel" :key="hotel.reservationId"></BookedHotel>
        <ConfirmDialog></ConfirmDialog>
    </div>
</template>
<script>
import BookedHotel from './BookedHotel.vue'
import ConfirmDialog from "primevue/confirmdialog";
import ProgressSpinner from 'primevue/progressspinner';
export default {
    data(){
        return{
            errorText: false
        }
    },
    components:{
        BookedHotel,
        ConfirmDialog,
        ProgressSpinner
    },
    created(){
        // Get booked hotels
        this.$store.dispatch('getBookings');
        console.log(this.$store.state.bookedHotels)

        setTimeout(function(that){
            if(!that.bookedHotels.length){
                that.errorText = true;
            }
        }, 10000, this)
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