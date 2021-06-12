<template>
    <div>
        <!-- <div v-if="!bookedHotels.length && !errorText">
        </div> -->
        <div v-if="!bookedHotels.length">
            <ProgressSpinner />
            <p>No bookings have been loaded. Try refreshing or create a booking for them to show up here!</p>
        </div>
        <BookedHotel v-for="hotel in displayList" :hotel="hotel" :key="hotel.reservationId"></BookedHotel>

        <Pagination v-model="page" :records="this.bookedHotels.length" :per-page="perPage" @paginate="myCallback"/>

        <ConfirmDialog></ConfirmDialog>
    </div>
</template>
<script>
import BookedHotel from './BookedHotel.vue'
import ConfirmDialog from "primevue/confirmdialog";
import ProgressSpinner from 'primevue/progressspinner';
//explanation: https://stackoverflow.com/questions/64604714/vue-pagination-how-to-use-it
import Pagination from 'v-pagination-3';

export default {
    data(){
        return{
            errorText: false,
            page: 1,
            perPage: 5,
            records:[]
        }
    },
    components:{
        BookedHotel,
        Pagination,
        ConfirmDialog,
        ProgressSpinner
    },
    created(){
        // Get booked hotels
        this.$store.dispatch('getBookings');

        for (let i = 1; i <= this.bookedHotels.length; i++) {
        this.records.push(`Item ${i}`);
        }

        if(!this.bookedHotels.length){
            this.errorText = true;
        }
    },
    computed:{
        bookedHotels(){
            return this.$store.state.bookedHotels;
        },
        displayList(){
            this.records = this.$store.state.bookedHotels;
            const startIndex = this.perPage * (this.page - 1);
            const endIndex = startIndex + this.perPage;
            return this.records.slice(startIndex, endIndex);
        }
    },
    methods:{
        myCallback: function(page) {
        // no need for callback here since you have all your data loaded already
        }
    }
}
</script>
