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
        hotel: {},
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
            extraBed: ''

        },
      
         reservation: {},
         user: {
            loggedIn: false,
          },
         customerDetailsCheckout: {}
      
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
            store.searchButtonLoading = false;
        },
        setHotel(store, value){
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
            console.log(store.searchAutoComplete);
        },
        setReservationDetails(state, data) {
            state.reservation = data;
        },
        setLoggedInUser(state, user) {
            state.user = user;
          },
        setEmail(state, value){
            state.user.Email = value; 
        },
        setPassword(state, value){
            state.user.Password = value;
        },
        setCustomerDetailsCheckout(state, data){
            state.customerDetailsCheckout = data;
        },
   },
   actions:{
        async searchHotels({commit}, searchString){
            let startDate;
            let endDate;
            console.log(this.state.searchString.dates);
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
            
            console.log(response);
            var result = await response.json();
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
            commit('setHotel', result);
        },
        async setHotel({commit}, hotel){
            console.log("set hotel action")
            console.log(hotel)
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
            console.log('action')
            var response = await fetch('https://localhost:44356/api/Search/GetSearchAutoComplete');
            var result = await response.json();
            console.log('result: ' + result)
            commit('setAutoComplete', result);
        },
        async login({ dispatch }, credentials) {
            let response = await fetch("https://localhost:44356/api/Guest/login", {
              method: "post",
              headers: { "Content-type": "application/json" },
              body: JSON.stringify(credentials),
            });
            let result = await response.json();
            await dispatch("getLoggedInUser", result);
          },

          async getLoggedInUser({ commit }) {
            let response = await fetch("https://localhost:44356/api/Guest/GetGuestById/");
            let result = await response.json();
            if (response.status == 401) {
              result.loggedIn = false;
            }
            commit("setLoggedInUser", result);
    
          },
          

          async logout({ dispatch }) {
            let response = await fetch("https://localhost:44356/api/Guest/login", { method: "delete" });
            //kolla response status etc
            await dispatch("getLoggedInUser");
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
            console.log(date);
            commit('setDates', date)
        },
        saveCustomerDetailsCheckout({ commit }, value){
            console.log("Updating customer details checkout")
            commit('setCustomerDetailsCheckout', value);
        }
    }
})

export default store;
