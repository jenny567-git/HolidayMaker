import { createStore } from "vuex" 
import router from "../router/index"

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

        }
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
        }
   },
   actions:{
        async searchHotels({commit}, searchString){
            console.log(this.state.searchString.dates);
            let date1 = this.state.searchString.dates[1].toDateString().split(" ");
            console.log(date1);
            //console.log(moment(this.state.searchString.dates[1]).format('YYYY-MM-DD'));
            //var response = await fetch('https://localhost:44356/api/Search/searchpeople?input=' + searchString.string + '&startDate=' + this.state.searchString.dates[0] + '&endDate=' + this.state.searchString.dates[1] + '&rooms=' + this.state.searchString.inputRooms + '&people=' + (this.state.searchString.inputAdult + this.state.searchString.inputChild))
            //var result = await response.json();
            //console.log(response);
        },
        // async searchHotels({commit}, searchString){
        //     var response = await fetch('https://localhost:44356/api/Search/GetSearchResultByName?input=' + searchString); // Default is GET
        //     var result = await response.json();
        //     console.log(searchString, result)
        //     commit('setHotelSeachResultsList', result);
        //     if(result){
        //         router.push({name: 'result'})
        //     }
        // },
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
        async searchSpecific({commit}, payload){
            window.scrollTo(0, 0)
            commit('setSearchString', payload.searchString);
            commit('setSearchButtonLoadingTrue', null);
            if(payload.type === 'city'){
                var response = await fetch('https://localhost:44356/api/Search/GetHotelByCity?input=' + payload.searchString); // Default is GET
                var result = await response.json();
                //console.log("searching for city: ",payload.type, payload.searchString, result)
                commit('setHotelSeachResultsList', result);

                setTimeout(function(){ // Timeout resolves inconsistent scroll behaviour between scrollTo and router.push
                    if(result){
                        router.push({name: 'result'})
                    }
                }, 500);
            }
            else{
                setTimeout(function(that){ 
                    that.dispatch('searchHotels', payload.searchString);
                }, 500, this); 
            }
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
        }
    }
})

export default store