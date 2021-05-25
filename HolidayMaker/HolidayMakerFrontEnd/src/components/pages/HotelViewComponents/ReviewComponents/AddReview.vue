<template>
    <div id="test2">
    <form @submit="onSubmit">
      <div class="pt-5">
        <RatingSlider v-model="rating" @clicked="onClickChild" />
        </div>
        <div class="form-group">
        <label for="exampleFormControlInput1">Your name</label>
        <input v-model="name" type="text" name='name' class="form-control" />
      </div>
      <div class="form-group">
        <label for="exampleFormControlInput1">Your email</label>
        <input v-model="email" type="email" name='email' class="form-control" />
      </div>
      <div class="form-group">
        <label for="exampleFormControlTextarea1">Your message</label>
        <textarea v-model="message" name='message' class="form-control" rows="3"></textarea>
      </div>
      <!-- <input type="submit" value="Submit" class="btn btn-block"/> -->
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>
import RatingSlider from './RatingSlider.vue'

  export default{
      components: {
        RatingSlider
    },
    data(){
      return{
        //bind to model
        name:'',
        email:'',
        message:'',
        rating:''
        // newReview: new Review()
      }
    },
    beforecreated(){
      console.log('created');
      this.onClickChild();
    },
    methods:{
      
      onClickChild(getValue){
        this.rating = getValue
        console.log(`onclickChild - ${this.rating}`)
      },
      onSubmit(e){
        e.preventDefault()

        if(!this.message || !this.name || !this.email){
          alert('Please fill in all fields')
          return
        }
        console.log(`in submit - ${this.rating}`)
        let newReview = {
            //id: 5,
            message: this.message,
            name: this.name,
            email: this.email,
            rating: `${this.rating}`
        }

        console.log(newReview)

        this.message=''
        this.name = ''
        this.email = ''
        this.rating=''
      }
    }
  }
</script>


<style scoped>
  #test2{
        border-radius: 30px;
        background-color: rgba(107, 146, 83, 0.5);
        padding-left: 25px;
        padding-right: 25px;
        padding-bottom: 40px;
        margin-top: 20px;
    }
</style>