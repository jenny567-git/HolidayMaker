<template>
  <form class="form1" @submit.prevent="checkPasswords">
    <div class="card-body">
      <div class="row gutters">
        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
          <h6 class="mb-2 text-primary">Personal Details</h6>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <div class="form-group">
            <label for="fullName">Full Name</label>
            <input
              type="text"
              class="form-control"
              id="fullName"
              :placeholder="user.fullName"
              v-model="guest.Fullname"
            />
          </div>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12"></div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <div class="form-group">
            <label for="website">Email</label>
            <input
              type="email"
              class="form-control"
              id="website"
              :placeholder="user.email"
              v-model="guest.Email"
            />
          </div>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <div class="form-group">
            <label for="phone">Phone</label>
            <input
              type="text"
              class="form-control"
              id="phone"
              :placeholder="user.phone"
              v-model="guest.Phone"
            />
          </div>
        </div>
      </div>
      <div class="row gutters">
        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
          <h6 class="mt-3 mb-2 text-primary">Address</h6>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <div class="form-group">
            <label for="Street">Street</label>
            <input
              type="text"
              class="form-control"
              id="Street"
              :placeholder="user.street"
              v-model="guest.Street"
            />
          </div>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <div class="form-group">
            <label for="ciTy">City</label>
            <input
              type="text"
              class="form-control"
              id="ciTy"
              :placeholder="user.city"
              v-model="guest.City"
            />
          </div>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <div class="form-group">
            <label for="zIp">Zip Code</label>
            <input
              type="text"
              class="form-control"
              id="zIp"
              :placeholder="user.zipCode"
              v-model="guest.Zipcode"
            />
          </div>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <div class="form-group">
            <label for="country">Country</label>
            <input
              type="text"
              class="form-control"
              id="country"
              :placeholder="user.country"
              v-model="guest.Country"
            />
          </div>
        </div>
        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
          <h6 class="mt-3 mb-2 text-primary">Password</h6>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
            <label for="sTate"> New Password</label>
          <div class="input-group flex-nowrap form-group">
            <input type="password" id="password" class="form-control" placeholder="Enter New Password" v-model="guest.Password">
          </div>
        </div>
        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
          <label for="zIp"> Verify Password</label>
          <div class="input-group flex-nowrap form-group">
            <input type="password" id="RePassword" class="form-control" placeholder="Re-enter Password" v-model="guest.confirmPassword">
          </div>
        </div>
      </div>
      <div class="row gutters">
        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
          <p class="text"></p>
          <div class="text-right">
            <button
              type="button"
              id="cancel"
              name="cancel"
              class="btn btn-secondary mr-1"
            >
              Cancel
            </button>
            <button
              type="button"
              id="update"
              name="update"
              class="btn btn-primary mr-1"
              @click="checkPasswords()"
            >
              Update
            </button>
            <button
              type="button"
              id="submit"
              name="submit"
              class="btn btn-danger"
              @click="deleteAccout()"
            >
              Delete your account
            </button>
          </div>
        </div>
      </div>
    </div>
  </form>
</template>

<script>
export default {
  components: {},
  data() {
    return {
      guest: {
        Fullname: "",
        Street: "",
        Zipcode: "",
        City: "",
        Country: "",
        Phone: "",
        Email: "",
        Password: "",
        confirmPassword: "",
        id:''
      },
    };
  },
  async mounted() {},
  methods: {
    checkPasswords() {
      var password = this.guest.Password;
      var confirmPassword = this.guest.confirmPassword;

      if (confirmPassword != password) {
        document.querySelector(".text").innerHTML = "Passwords dont match";
      } else if (password === confirmPassword) {
        document.querySelector(".text").innerHTML = "";
        this.updateGuest();
      }
    },
    async updateGuest() {
      var id = this.user.id;
      await fetch("https://localhost:44356/api/Guest/updateGuest", {
        method: "Post",
        headers: {
          Accept: "application/json",
          "Content-type": "application/json",
        },

        body: JSON.stringify({
          Id: id,
          Fullname: this.guest.Fullname,
          Street: this.guest.Street,
          Zipcode: this.guest.Zipcode,
          City: this.guest.City,
          Country: this.guest.Country,
          Phone: this.guest.Phone,
          Email: this.guest.Email,
          Password: this.guest.Password,
        }),
      });
      this.$router.go()
    },
    resetForm() {
      document.querySelector(".form1").reset();
    },
    deleteAccout() {
      let credentials = this.user.id;
      if (confirm("Do you really want to delete your account?")) {
        this.$store.dispatch("deleteGuestAccount", credentials);
      }
    },
  },
  computed: {
    loggedIn() {
      return this.$store.state.user.loggedIn;
    },
    user() {
      return this.$store.state.user;
    },
  },
};
</script>

<style scoped>
label {
  color: black;
}

.text {
  color: red;
}

#update{
  background-color: rgb(83 193 110);
  border: #0e833d
}
</style>
