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
        hotels:
            [
                {
                    id: 1,
                    name: 'Hotel ajgipjdfjsjdfisdjfopia',
                    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer dapibus lacus a diam rhoncus suscipit. Nulla facilisi. Maecenas non metus faucibus, feugiat lectus non, elementum urna. Morbi viverra gravida diam, et tincidunt felis laoreet vitae. Suspendisse vel metus non ex tempus tincidunt. Proin egestas sapien nisi, eu elementum est aliquet.'
                },
                {
                    id: 2,
                    name: 'Hotel ijaefioeijfaiheouyfaehcaj',
                    description: 'In varius, nisi quis blandit porta, dolor tortor aliquam odio, eget consectetur lectus leo a massa. Proin dignissim dignissim porttitor. Praesent sed risus id diam dapibus consectetur. Vivamus sollicitudin urna ut tincidunt varius. Morbi congue malesuada erat id luctus. Nunc.'
                }],
        searchString: {
            string: '',
            inputAdult: 0,
            inputChild: 0,
            inputRooms: 0,
            dates: []
        },
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
      
        reservation: {
            fullName: 'sadas',
            hotelName: 'sds',
            startDate: '',
            endDate: '',
            adults: '',
            children: '',
            customerMessage: '',
            type: '',
            totalPrice: '',
            hotelRoomsViewModel:{
              singleRooms: '2',
              doubleRooms: '2',
              familyRooms: '2'
            }
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
        setCustomerDetailsCheckout(state, data){
            state.customerDetailsCheckout = data;
        }
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
