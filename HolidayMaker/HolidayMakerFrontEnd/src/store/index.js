import { createStore } from "vuex";
import router from "../router/index";

const store = createStore({
    state: {
        searchButtonLoading: false,
        guestId: 33, // hard coded
        home: {title: "store name"},
        name: "Vue",        
        hotels: [],
        searchString: {
            string: '',
            inputAdult: 0,
            inputChild: 0,
            inputRooms: 0,
            dates: []
        },
        searchAutoComplete: [],
        seachResults: [],
        hotel: [],
        user: {
            loggedIn: false,
        },
        bookingDetails: {
            hotelId: '',
            noOfSingleRooms: 0,
            noOfDoubleRooms: 0,
            noOfFamilyRooms: 0,
            unitPriceSingleRoom: 0,
            unitPriceDoubleRoom: 0,
            unitPriceFamilyRoom: 0,
            serviceType: 'SelfService',
            serviceFee: 0,
            extraBed: false,
            extraBedFee: 0,
            totalprice: ''

        },
      
         reservation: {},
         guest:{},        
         
       
         user: {
            loggedIn: false,
          },
         savedHotels:[],
    },
      
    
    mutations: {
        setEmail(store, value) {
            store.addReview.email = value
        },
        setMessage(store, value) {
            store.addReview.message = value
        },
        setSearchButtonLoadingTrue(store, value) {
            store.searchButtonLoading = true;
        },
        setHotelSeachResultsList(store, value) {
            store.seachResults = value;
            // console.log('set search result');
            // console.log(store.seachResults);
            store.searchButtonLoading = false;
        },
        setHotel(store, value) {
            // console.log(value);
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
        setSearchString(state, value) {
            state.searchString.string = value;
        },
        setAutoComplete(store, value) {
            store.searchAutoComplete = value;
        },
        setReservationDetails(state, data) {
            state.reservation = data;
        },
        setSingleRooms(state, { noOfUnit, unitPrice }) {
            state.bookingDetails.noOfSingleRooms = noOfUnit
            state.bookingDetails.unitPriceSingleRoom = unitPrice
        },
        setDoubleRooms(state, { noOfUnit, unitPrice }) {
            state.bookingDetails.noOfDoubleRooms = noOfUnit
            state.bookingDetails.unitPriceDoubleRoom = unitPrice
        },
        setLoggedInUser(state, data) {
            state.user = data;
            console.log(data)
          },
        setEmail(state, value){
            state.user.Email = value; 
        },
        setFamilyRooms(state, { noOfUnit, unitPrice }) {
            state.bookingDetails.noOfFamilyRooms = noOfUnit
            state.bookingDetails.unitPriceFamilyRoom = unitPrice
        },
        getTotalPrice(state) {
            let singleRoomsTotalPrice = state.bookingDetails.noOfSingleRooms * state.bookingDetails.unitPriceSingleRoom;
            let doubleRoomsTotalPrice = state.bookingDetails.noOfDoubleRooms * state.bookingDetails.unitPriceDoubleRoom;
            let familyRoomsTotalPrice = state.bookingDetails.noOfFamilyRooms * state.bookingDetails.unitPriceFamilyRoom;

            let servicePrice = state.bookingDetails.serviceFee;

            state.bookingDetails.totalprice = singleRoomsTotalPrice + doubleRoomsTotalPrice + familyRoomsTotalPrice + servicePrice;

            if (state.bookingDetails.extraBed) {
                state.bookingDetails.totalprice += state.bookingDetails.extraBedFee;
            }

        },
        updateExtraBed(state) {
            state.bookingDetails.extraBed = (state.bookingDetails.extraBed != true) ? true : false;
        },
        setExtraBedFee(state, value) {
            state.bookingDetails.extraBedFee = value;
        },
        setServiceType(state, value) {
            state.bookingDetails.serviceType = value;
        },
        setServiceFee(state, value) {
            console.log('in mutation set service');
            console.log('value' + value);
            state.bookingDetails.serviceFee = value;
        },
   
        setPassword(state, value){
            state.user.Password = value;
        },
        setSavedHotels(state, data){
            state.savedHotels = data;
        },
        setUser(state, data){
            state.user = data
            state.user.loggedIn = true;
            console.log(data)
            
        },
                
        logOutUser(state){
            
            state.user.loggedIn=false;
            
        },
        setGuest(state, data){
            state.guest = data;
        },
        
        setUser(state, data){
            state.user = data
            state.user.loggedIn = true;
            console.log(data)
            
        },
                
        logOutUser(state){
            
            state.user.loggedIn=false;
            
        }

   },
   actions:{
        async searchHotels({commit}, searchString){
            let startDate;
            let endDate;
            if (this.state.searchString.dates.length) {
                startDate = this.state.searchString.dates[0].toISOString().slice(0, 10);
                endDate = this.state.searchString.dates[1].toISOString().slice(0, 10);
            }
            //search with all values but no string
            if (searchString === null || searchString == '') {
                var response = await fetch('https://localhost:44356/api/Search/search?startDate=' + startDate + '&endDate=' + endDate + '&rooms=' + this.state.searchString.inputRooms + '&people=' + (this.state.searchString.inputAdult + this.state.searchString.inputChild));
                //search with only string
            } else if (!this.state.searchString.dates.length) {
                var response = await fetch('https://localhost:44356/api/Search/search?input=' + searchString);
                //search with all values
            } else {
                var response = await fetch('https://localhost:44356/api/Search/search?startDate=' + startDate + '&endDate=' + endDate + '&rooms=' + this.state.searchString.inputRooms + '&people=' + (this.state.searchString.inputAdult + this.state.searchString.inputChild) + '&input=' + searchString)
            }
            var result = await response.json();
            // console.log('search hotel');
            // console.log(result);
            commit('setHotelSeachResultsList', result);
            if (result) {
                router.push({ name: 'result' })
            }
        },
        async searchHotelByName({ commit }, searchString) {
            var response = await fetch('https://localhost:44356/api/Search/search?input=' + searchString); // Default is GET
            var result = await response.json();
            console.log(searchString, result)
            if (result) {
                commit('setHotelSeachResultsList', result);
                router.push({ name: 'result' })
            }
        },
        async getHotelById({ commit }, hotelId) {
            var response = await fetch('https://localhost:44356/api/Hotel/GetById/' + hotelId); // Default is GET
            var result = await response.json();
            console.log('getHotelById action');
            commit('setHotel', result);
        },
        async setHotel({ commit }, hotel) {
            commit('setHotel', hotel)
        },
        async getReservationById({ commit }, reservationId) {
            var response = await fetch(
                "https://localhost:44356/api/Booking/Booking/" + reservationId
            );
            var result = await response.json();

            commit("setReservationDetails", result);
        },
        async searchHotelByCity({ commit }, searchString) {
            var response = await fetch('https://localhost:44356/api/Search/GetHotelByCity?input=' + searchString); // Default is GET
            var result = await response.json();
            console.log(searchString, result)
            if (result) {
                commit('setHotelSeachResultsList', result);
                router.push({ name: 'result' })
            }
        },
        async searchSpecific({ commit }, payload) {
            window.scrollTo(0, 0)
            commit('setSearchString', payload.searchString);
            commit('setSearchButtonLoadingTrue', null);
            setTimeout(function (that) { // Timeout resolves inconsistent scroll behaviour between scrollTo and router.push
                if (payload.type === 'city') {
                    that.dispatch('searchHotelByCity', payload.searchString);
                }
                else {
                    that.dispatch('searchHotelByName', payload.searchString);
                }
            }, 500, this);
        },
        async getAutoComplete({ commit }) {
            var response = await fetch('https://localhost:44356/api/Search/GetSearchAutoComplete');
            var result = await response.json();
            commit('setAutoComplete', result);
        },
        
        async getSavedHotelsInfo({commit}){
            console.log('Getting saved hotels for guest id ', this.state.guestId)
            var response = await fetch('https://localhost:44356/api/Hotel/SavedHotelsInfo?id=' + this.state.guestId);
            var result = await response.json();
            if(result){
                console.log(result);
                commit('setSavedHotels', result);
            }
        },
        async addFavouriteHotel({commit}, hotelId){
            fetch('https://localhost:44356/api/Guest/saveFavoriteHotel',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json'},
                body: JSON.stringify({hotelID: hotelId, guestID: this.state.guestId})
            })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
        },
        async removeFavouriteHotel({commit}, hotelId){
            fetch('https://localhost:44356/api/Guest/removeFavoriteHotel',
            {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json'},
                body: JSON.stringify({hotelID: hotelId, guestID: this.state.guestId})
            })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
            })
            .catch((error) => {
                console.error('Error:', error);
            }); 
            
        },
        async login({ commit }, credentials) {
           
            let response = await fetch("https://localhost:44356/api/Guest/login", {
              method: "post",
              headers: { "Content-type": "application/json" },
              body: JSON.stringify(credentials),
            });
            let result = await response.json();
            
            commit("setUser",  result );
            Cookies.set("login", "true" )
            Cookies.set("userId", result.id)
            
            router.push('/')
           
          },
          checkLoggedInUser({commit}){
            console.log("dkjgb")
            var myCookie = Cookies.get('login')
            if(myCookie){
                this.dispatch('login',{Email: "", Password:"", UserID:Cookies.get('userId')})
            }
            
        },

          async logout({ commit }) {
            // let response = await fetch("https://localhost:44356/api/Guest/login", {
            //   method: "post",
            //   headers: { "Content-type": "application/json" },
            //   body: JSON.stringify(credentials),
            // });
            // let result = await response.json();
            Cookies.remove('userId')
            Cookies.remove('login')
            commit("logOutUser");
            router.push("/")
          
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
        setSingleRooms({ commit }, { noOfUnit, unitPrice }) {
            commit('setSingleRooms', { noOfUnit, unitPrice })
        },
        setDoubleRooms({ commit }, { noOfUnit, unitPrice }) {
            commit('setDoubleRooms', { noOfUnit, unitPrice })
        },
        setFamilyRooms({ commit }, { noOfUnit, unitPrice }) {
            commit('setFamilyRooms', { noOfUnit, unitPrice })
        },
        getTotalPrice({ commit }) {
            commit('getTotalPrice')
        },
        updateExtraBed({ commit }) {
            commit('updateExtraBed')
        },
        setExtraBedFee({ commit }, value) {
            commit('setExtraBedFee', value)
        },
        setServiceType({ commit }, value) {
            commit('setServiceType', value)
        },
        async setServiceFee({ commit }, payload) {
            // console.log('in action set service');
            var response = await fetch('https://localhost:44356/api/Hotel/GetAccomodationFee?id=' + payload.id + '&type=' + payload.type);
            var result = await response.json();
            commit('setServiceFee', result)
        },
    }
})

export default store;
