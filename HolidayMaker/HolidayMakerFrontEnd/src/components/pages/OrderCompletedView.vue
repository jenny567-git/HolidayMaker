<template>
    <div>
        <div class="container-fluid">
	    <div class="row">
		<div class="col-md-12">
			<h3 v-if="completed" class="text-center">Order Completed!</h3>
            <h3 v-else class="text-center">Order Failed!</h3>
            <img alt="Bootstrap Image Preview" :src="statusLogo" class="rounded-circle" />
			<dl>
				<dt>
					Order details
				</dt>
				<dd>
					A description list is perfect for defining terms.
				</dd>
				<dt>
					Euismod
				</dt>
				<dd>
					Vestibulum id ligula porta felis euismod semper eget lacinia odio sem nec elit.
				</dd>
				<dd>
					Donec id elit non mi porta gravida at eget metus.
				</dd>
				<dt>
					Malesuada porta
				</dt>
				<dd>
					Etiam porta sem malesuada magna mollis euismod.
				</dd>
				<dt>
					Felis euismod semper eget lacinia
				</dt>
				<dd>
					Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.
				</dd>
			</dl>
		</div>
        </div>
        </div>
    </div>
</template>
<script>
export default {
    props:{
        completed: {}
    },
    data(){
        return{
            completed: true // remove when actually getting the completion status!
        }
    },
    computed:{
        statusLogo(){
            return this.completed ? "https://raw.githubusercontent.com/PKief/vscode-markdown-checkbox/master/logo.png" 
            : "https://icon-library.com/images/failed-icon/failed-icon-6.jpg";
        }
    }
}
</script>
<style lang="">
    
</style>