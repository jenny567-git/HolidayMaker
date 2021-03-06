import { createStore } from 'vuex'
import router from '../router/index'

const store = createStore({
  state: {
    searchButtonLoading: false,
    guestId: 33, // hard coded
    home: { title: 'store name' },
    name: 'Vue',
    addReview: {
      name: '',
      email: '',
      message: '',
    },
    getReviews: [],
    hotels: [],
    searchString: {
      string: '',
      inputAdult: 0,
      inputChild: 0,
      inputRooms: 0,
      dates: [],
    },
    savedHotel: [],
    bookedHotels: [],
    searchAutoComplete: [],
    seachResults: [],
    hotel: [],
    user: {
      loggedIn: false,
    },
    bookingDetails: {
      hotelId: '',
      hotelName: '',
      noOfSingleRooms: 0,
      noOfDoubleRooms: 0,
      noOfFamilyRooms: 0,
      singleRoomId: 0,
      doubleRoomId: 0,
      familyRoomId: 0,
      unitPriceSingleRoom: 0,
      unitPriceDoubleRoom: 0,
      unitPriceFamilyRoom: 0,
      serviceType: '',
      serviceFee: 0,
      extraBed: false,
      extraBedFee: 0,
      totalprice: '',
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
      extraBed: null,
      hotelRoomsViewModel: {
        singleRooms: '2',
        doubleRooms: '2',
        familyRooms: '2',
      },
    },
    customerDetailsCheckout: {},
    orderId: '',
    user: {
      loggedIn: false,
    },
  },
  mutations: {
    setEmail(store, value) {
      store.addReview.email = value
    },
    setMessage(store, value) {
      store.addReview.message = value
    },
    setSearchButtonLoadingTrue(store, value) {
      store.searchButtonLoading = true
    },
    setHotelSeachResultsList(store, value) {
      store.seachResults = value
      store.searchButtonLoading = false
    },
    setHotel(store, value) {
      store.hotel = value
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
      state.searchString.string = value
    },
    setAutoComplete(store, value) {
      store.searchAutoComplete = value
    },
    setReservationDetails(state, data) {
      state.reservation = data
    },
    setHotelName(state, data) {
      state.bookingDetails.hotelName = data
    },
    getReviews(state, data) {
      state.getReviews = data
    },
    setSingleRooms(state, { noOfUnit, unitPrice, roomId }) {
      state.bookingDetails.noOfSingleRooms = noOfUnit
      state.bookingDetails.unitPriceSingleRoom = unitPrice
      state.bookingDetails.singleRoomId = roomId
    },
    setDoubleRooms(state, { noOfUnit, unitPrice, roomId }) {
      state.bookingDetails.noOfDoubleRooms = noOfUnit
      state.bookingDetails.unitPriceDoubleRoom = unitPrice
      state.bookingDetails.doubleRoomId = roomId
    },
    setFamilyRooms(state, { noOfUnit, unitPrice, roomId }) {
      state.bookingDetails.noOfFamilyRooms = noOfUnit
      state.bookingDetails.unitPriceFamilyRoom = unitPrice
      state.bookingDetails.familyRoomId = roomId
    },
    getTotalPrice(state) {
      var days = Math.floor(
        (Date.parse(state.searchString.dates[1].toLocaleDateString('sv-SE')) -
          Date.parse(state.searchString.dates[0].toLocaleDateString('sv-SE'))) /
          86400000
      )

      let singleRoomsTotalPrice =
        state.bookingDetails.noOfSingleRooms *
        state.bookingDetails.unitPriceSingleRoom *
        days
      let doubleRoomsTotalPrice =
        state.bookingDetails.noOfDoubleRooms *
        state.bookingDetails.unitPriceDoubleRoom *
        days
      let familyRoomsTotalPrice =
        state.bookingDetails.noOfFamilyRooms *
        state.bookingDetails.unitPriceFamilyRoom *
        days

      let servicePrice = state.bookingDetails.serviceFee

      state.bookingDetails.totalprice =
        singleRoomsTotalPrice +
        doubleRoomsTotalPrice +
        familyRoomsTotalPrice +
        servicePrice

      if (state.bookingDetails.extraBed) {
        state.bookingDetails.totalprice += state.bookingDetails.extraBedFee
      }
    },
    updateExtraBed(state) {
      state.bookingDetails.extraBed =
        state.bookingDetails.extraBed != true ? true : false
    },
    setExtraBedFee(state, value) {
      state.bookingDetails.extraBedFee = value
    },
    setServiceType(state, value) {
      state.bookingDetails.serviceType = value
    },
    setServiceFee(state, value) {
      state.bookingDetails.serviceFee = value
    },
    setCustomerDetailsCheckout(state, data) {
      state.customerDetailsCheckout = data
    },
    setUser(state, data) {
      state.user = data
      state.user.loggedIn = true
    },

    logOutUser(state) {
      state.user.loggedIn = false
    },
    setEmail(state, value) {
      state.user.Email = value
    },
    setPassword(state, value) {
      state.user.Password = value
    },
    setBookedHotels(state, value) {
      state.bookedHotels = value
    },
    setSavedHotels(state, data) {
      state.savedHotels = data
    },
    setOrderId(state, value) {
      state.orderId = value
    },
    clearBookingDetails(state) {
      ;(state.bookingDetails.hotelId = ''),
        (state.bookingDetails.hotelName = ''),
        (state.bookingDetails.noOfSingleRooms = 0),
        (state.bookingDetails.noOfDoubleRooms = 0),
        (state.bookingDetails.noOfFamilyRooms = 0),
        (state.bookingDetails.singleRoomId = 0),
        (state.bookingDetails.doubleRoomId = 0),
        (state.bookingDetails.familyRoomId = 0),
        (state.bookingDetails.unitPriceSingleRoom = 0),
        (state.bookingDetails.unitPriceDoubleRoom = 0),
        (state.bookingDetails.unitPriceFamilyRoom = 0),
        (state.bookingDetails.serviceType = ''),
        (state.bookingDetails.serviceFee = 0),
        (state.bookingDetails.extraBed = false),
        (state.bookingDetails.extraBedFee = 0)
      state.bookingDetails.totalprice = '',
      state.seachResults = [],
      state.searchString.dates = []
    },
    setHotelId(state, value) {
      state.bookingDetails.hotelId = value
    },
  },
  actions: {
    saveCustomerDetailsCheckout({ commit }, data) {
      commit('setCustomerDetailsCheckout', data)
    },
    async searchHotels({ commit }, searchString) {
      router.push({ name: 'result' })
      let startDate
      let endDate
      if (this.state.searchString.dates.length) {
        startDate = this.state.searchString.dates[0].toLocaleDateString('sv-SE')
        endDate = this.state.searchString.dates[1].toLocaleDateString('sv-SE')
      }
      //search with all values but no string
      if (searchString === null || searchString == '') {
        var response = await fetch(
          'https://localhost:44356/api/Search/search?startDate=' +
            startDate +
            '&endDate=' +
            endDate +
            '&rooms=' +
            this.state.searchString.inputRooms +
            '&people=' +
            (this.state.searchString.inputAdult +
              this.state.searchString.inputChild)
        )
        //search with only string
      } else if (!this.state.searchString.dates.length) {
        var response = await fetch(
          'https://localhost:44356/api/Search/search?input=' + searchString
        )
        //search with all values
      } else {
        var response = await fetch(
          'https://localhost:44356/api/Search/search?startDate=' +
            startDate +
            '&endDate=' +
            endDate +
            '&rooms=' +
            this.state.searchString.inputRooms +
            '&people=' +
            (this.state.searchString.inputAdult +
              this.state.searchString.inputChild) +
            '&input=' +
            searchString
        )
      }
      var result = await response.json()
      commit('setHotelSeachResultsList', result)
      if (result) {
        router.push({ name: 'result' })
      }
    },
    async searchHotelByName({ commit }, searchString) {
      var response = await fetch(
        'https://localhost:44356/api/Search/search?input=' + searchString
      ) // Default is GET
      var result = await response.json()
      if (result) {
        commit('setHotelSeachResultsList', result)
        router.push({ name: 'result' })
      }
    },
    async getHotelById({ commit }, hotelId) {
      var response = await fetch(
        'https://localhost:44356/api/Hotel/GetById/' + hotelId
      ) // Default is GET
      var result = await response.json()
      commit('setHotel', result)
    },
    async setHotel({ commit }, hotel) {
      commit('setHotel', hotel)
    },
    async getReservationById({ commit }, reservationId) {
      var response = await fetch(
        'https://localhost:44356/api/Booking/' + reservationId
      )
      var result = await response.json()
      commit('setReservationDetails', result)
    },
    async searchHotelByCity({ commit }, searchString) {
      var response = await fetch(
        'https://localhost:44356/api/Search/GetHotelByCity?input=' +
          searchString
      ) // Default is GET
      var result = await response.json()
      if (result) {
        commit('setHotelSeachResultsList', result)
        router.push({ name: 'result' })
      }
    },
    async searchSpecific({ commit }, payload) {
      window.scrollTo(0, 0)
      commit('setSearchString', payload.searchString)
      commit('setSearchButtonLoadingTrue', null)
      setTimeout(
        function (that) {
          // Timeout resolves inconsistent scroll behaviour between scrollTo and router.push
          if (payload.type === 'city') {
            that.dispatch('searchHotelByCity', payload.searchString)
          } else {
            that.dispatch('searchHotelByName', payload.searchString)
          }
        },
        500,
        this
      )
    },
    async getAutoComplete({ commit }) {
      var response = await fetch(
        'https://localhost:44356/api/Search/GetSearchAutoComplete'
      )
      var result = await response.json()
      commit('setAutoComplete', result)
    },
    async login({ commit }, credentials) {
      let response = await fetch('https://localhost:44356/api/Guest/login', {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(credentials),
      })
      let result = await response.json()

      if (result.message == 'Username or password is incorrect') {
        document.querySelector('.text').innerHTML = result.message
      } else {
        commit('setUser', result)
        Cookies.set('login', 'true')
        Cookies.set('userId', result.id)
        router.push('/profile')
      }
    },
    checkLoggedInUser({ commit }) {
      var myCookie = Cookies.get('login')
      if (myCookie) {
        this.dispatch('login', {
          Email: '',
          Password: '',
          UserID: Cookies.get('userId'),
        })
      }
    },
    async logout({ commit }) {
      Cookies.remove('userId')
      Cookies.remove('login')
      commit('logOutUser')
      router.push('/')
    },
    async getSavedHotelsInfo({ commit }) {
      var response = await fetch(
        'https://localhost:44356/api/Hotel/SavedHotelsInfo?id=' +
          this.state.user.id
      )
      var result = await response.json()
      if (result) {
        commit('setSavedHotels', result)
      }
      else{
        commit("setSavedHotels", []);
      }
    },
    async addFavouriteHotel({ commit }, hotelId) {
      fetch('https://localhost:44356/api/Guest/saveFavoriteHotel', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ hotelID: hotelId, guestID: this.state.user.id }),
      })
        .then((response) => response.json())
        .then((data) => {
          console.log('Success:', data)
        })
        .catch((error) => {
          console.error('Error:', error)
        })
    },
    async removeFavouriteHotel({ commit }, hotelId) {
      fetch('https://localhost:44356/api/Guest/removeFavoriteHotel', {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ hotelID: hotelId, guestID: this.state.user.id }),
      })
        .then((response) => response.json())
        .then((data) => {
          console.log('Success:', data)
        })
        .catch((error) => {
          console.error('Error:', error)
        })
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
    async getReviews({ commit }, hotelId) {
      var response = await fetch(
        'https://localhost:44356/api/Hotel/GetReviews/' + hotelId
      )
      var result = await response.json()
      commit('getReviews', result)
    },
    setSingleRooms({ commit }, { noOfUnit, unitPrice, roomId }) {
      commit('setSingleRooms', { noOfUnit, unitPrice, roomId })
    },
    setDoubleRooms({ commit }, { noOfUnit, unitPrice, roomId }) {
      commit('setDoubleRooms', { noOfUnit, unitPrice, roomId })
    },
    setFamilyRooms({ commit }, { noOfUnit, unitPrice, roomId }) {
      commit('setFamilyRooms', { noOfUnit, unitPrice, roomId })
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
    setHotelName({ commit }, value) {
      commit('setHotelName', value)
    },
    setServiceType({ commit }, value) {
      commit('setServiceType', value)
    },
    async setServiceFee({ commit }, payload) {
      var response = await fetch(
        'https://localhost:44356/api/Hotel/GetAccomodationFee?id=' +
          payload.id +
          '&type=' +
          payload.type
      )
      var result = await response.json()
      commit('setServiceFee', result)
    },
    deleteGuestAccount({ commit }, Id) {
      fetch('https://localhost:44356/api/Guest/removeGuest', {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({ Id: Id }),
      })
      Cookies.remove('userId')
      Cookies.remove('login')
      commit('logOutUser')
      router.push('/')
    },
    async getBookings({ commit }) {
      var response = await fetch(
        'https://localhost:44356/api/Booking/guest/' + this.state.user.id
      )
      var result = await response.json()
      commit('setBookedHotels', result)
    },
    async setOrderId({ commit }, value) {
      commit('setOrderId', value)
    },
    clearCart({ commit }) {
      commit('clearBookingDetails')
    },
    setHotelId({ commit }, value) {
      commit('setHotelId', value)
    },
  },
})

export default store
