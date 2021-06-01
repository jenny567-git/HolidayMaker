import { createStore } from "vuex";
import router from "../router/index";

const store = createStore({
    state:{
        searchButtonLoading: false,
        home: {title: "store name"},
        name: "Vue",
        addReview: {
            name: '',
            email: '',
            message: ''
        },
        getReviews: [],
        hotels:[],
        searchString: {
            string: '',
            inputAdult: 0,
            inputChild: 0,
            inputRooms: 0,
            dates: []
        },
        searchAutoComplete: [],
        seachResults:[],
        hotel: [],
        user: {
            loggedIn: false,
        },
        bookingDetails: {
            hotelId: '',
            rooms: [
                {
                    type: '1',
                    nrOfRooms: ''
                },
                {
                    type: '2',
                    nrOfRooms: ''
                },
                {
                    type: '3',
                    nrOfRooms: ''
                }
            ],
            serviceType: '',
            extraBed: '',
            totalprice:''

        },
      
         reservation: {},
      
    },
    mutations: {
        setEmail(store, value) {
            store.addReview.email = value
        },
        setMessage(store, value) {
            store.addReview.message = value
        },
        setSearchButtonLoadingTrue(store, value){
            store.searchButtonLoading = true;
        },
        setHotelSeachResultsList(store, value){
            store.seachResults = value;
            console.log('set search result');
            console.log(store.seachResults);
            store.searchButtonLoading = false;
        },
        setHotel(store, value){
            console.log(value);
            store.hotel = value;
        },
        updateAdults(state, value) {
            state.searchString.inputAdult = value
        },
        updateChild(state, value) {
            state.searchString.inputChild = value
        },
        updateRoom(state, value) {
            state.searchString.inputRooms = value
        },
        setDates(state, date) {
            state.searchString.dates = date
        },
        setSearchString(state, value){
            state.searchString.string = value;
        },
        setAutoComplete(store, value){
            store.searchAutoComplete = value;
        },
        setReservationDetails(state, data) {
            state.reservation = data;
        },
        getReviews(state, data){
            state.getReviews = data;
        },
        //prop not available in state yet
        setSingleRooms(state, value) {
            state.bookingDetails.inputSingleRooms = value
        },
        //prop not available in state yet
        setDoubleRooms(state, value) {
            state.bookingDetails.inputDoubleRooms = value
        },
        //prop not available in state yet
        setFamilyRooms(state, value) {
            state.bookingDetails.inputFamilyRooms = value
        },
        setTotalPrice(state) {
            let singleRooms = state.bookingDetails.inputSingleRooms;
            let doubleRooms = state.bookingDetails.inputDoubleRooms;
            let familyRooms = state.bookingDetails.inputFamilyRooms;
            state.bookingDetails.totalprice = 0;
        },
   },
   actions:{
        async searchHotels({commit}, searchString){
            let startDate;
            let endDate;
            if(this.state.searchString.dates.length){
                startDate = this.state.searchString.dates[0].toISOString().slice(0,10);
                endDate = this.state.searchString.dates[1].toISOString().slice(0,10);
            }
            //search with all values but no string
            if(searchString === null || searchString == ''){
                var response = await fetch('https://localhost:44356/api/Search/search?startDate=' + startDate + '&endDate=' + endDate + '&rooms=' + this.state.searchString.inputRooms + '&people=' + (this.state.searchString.inputAdult + this.state.searchString.inputChild));
            //search with only string
            } else if(!this.state.searchString.dates.length){
                var response = await fetch('https://localhost:44356/api/Search/search?input=' + searchString);
            //search with all values
            } else {
                var response = await fetch('https://localhost:44356/api/Search/search?startDate=' + startDate + '&endDate=' + endDate + '&rooms=' + this.state.searchString.inputRooms + '&people=' + (this.state.searchString.inputAdult + this.state.searchString.inputChild) + '&input=' + searchString)
            }
            var result = await response.json();
            // console.log('search hotel');
            // console.log(result);
            commit('setHotelSeachResultsList', result);
            if(result){
                router.push({name: 'result'})
            }
        },
        async searchHotelByName({commit}, searchString){
            var response = await fetch('https://localhost:44356/api/Search/search?input=' + searchString); // Default is GET
            var result = await response.json();
            console.log(searchString, result)
            if(result){
                commit('setHotelSeachResultsList', result);
                router.push({name: 'result'})
            }
        },
        async getHotelById({commit}, hotelId){
            var response = await fetch('https://localhost:44356/api/Hotel/GetById/' + hotelId); // Default is GET
            var result = await response.json();
            console.log('getHotelById action');
            commit('setHotel', result);
        },
        async setHotel({commit}, hotel){
            commit('setHotel', hotel)
       },
       async getReservationById({ commit }, reservationId) {
           var response = await fetch(
               "https://localhost:44356/api/Booking/Booking/" + reservationId
           );
           var result = await response.json();

           commit("setReservationDetails", result);
       },
       async searchHotelByCity({commit}, searchString){
            var response = await fetch('https://localhost:44356/api/Search/GetHotelByCity?input=' + searchString); // Default is GET
            var result = await response.json();
            console.log(searchString, result)
            if(result){
                commit('setHotelSeachResultsList', result);
                router.push({name: 'result'})
            }
       },
        async searchSpecific({commit}, payload){
            window.scrollTo(0, 0)
            commit('setSearchString', payload.searchString);
            commit('setSearchButtonLoadingTrue', null);
            setTimeout(function(that){ // Timeout resolves inconsistent scroll behaviour between scrollTo and router.push
                if(payload.type === 'city'){
                    that.dispatch('searchHotelByCity', payload.searchString);
                }
                else{
                    that.dispatch('searchHotelByName', payload.searchString);
                }
            }, 500, this);
        },
        async getAutoComplete({commit}){
            var response = await fetch('https://localhost:44356/api/Search/GetSearchAutoComplete');
            var result = await response.json();
            commit('setAutoComplete', result);
        },
        updateAdults({ commit }, value) {
            commit('updateAdults', value)
        },
        updateChild({ commit }, value) {
            commit('updateChild', value)
        },
        updateRoom({ commit }, value) {
            commit('updateRoom', value)
        },
        setDates({ commit }, date) {
            commit('setDates', date)
        },
        async getReviews({commit}, hotelId){
            var response = await fetch('https://localhost:44356/api/Hotel/GetReviews/' + hotelId);
            var result = await response.json();
            commit('getReviews', result);
        },
        setSingleRooms({ commit }, value) {
            commit('setSingleRooms', value)
        },
        setDoubleRooms({ commit }, value) {
            commit('setDoubleRooms', value)
        },
        setFamilyRooms({ commit }, value) {
            commit('setFamilyRooms', value)
        },
        setTotalPrice({ commit }) {
            commit('setTotalPrice')
        },
    }
})

export default store;
