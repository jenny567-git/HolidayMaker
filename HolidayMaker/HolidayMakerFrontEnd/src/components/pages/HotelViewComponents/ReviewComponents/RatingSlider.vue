<template>
<div>
    <div>
        <div class="row">        
        <div class="col-md-6">
            <p>Rating (0-5)</p>
        </div>
        <div class="col-md-6">
            <Slider v-model="ratingRange.value" v-bind="ratingRange" :format="format" :max="5" @change="emitToParent" ></Slider>
        </div>
        </div>
    </div>
    
  </div>
</template>

<script>
// code: https://www.vuescript.com/custom-range-slider/
import Slider from '/node_modules/@vueform/slider'

export default {
    components: { 
        Slider 
        },
      data() {
         return {
                ratingRange: {
                        value: [0]
                        },
                format: function(value){
                    if(value == 0){return `Very Bad - ${value}`
                    } else if(value == 1){return `Bad - ${value}`
                    } else if(value == 2 ){return `OK - ${value}`
                    } else if(value == 3){return `Good - ${value}`
                    } else if(value == 4){return `Very Good - ${value}`
                    } else { return `Excellent - ${value}`}  
                    
                },
                //ratingValue: ''
      } 
      },
      created(){
          this.emitToParent('clicked', this.ratingRange.value);
      },
      methods:{
        emitToParent(e){
            this.$emit('clicked', this.ratingRange.value)
        }
      }
}
</script>

<style src="@vueform/slider/themes/default.css"></style>

<style scoped>

</style>