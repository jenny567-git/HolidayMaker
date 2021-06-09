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
    async created(){
        // Get booked hotels
        await this.$store.dispatch('getBookings');
        
        if(!this.bookedHotels.length){
            this.errorText = true;
        }
        
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