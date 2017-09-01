<template>
	<div id="Root" class="root-div">
		<master></master>
		<detail></detail>
	</div>
</template>

<script>
	import master from './master.vue'
	import detail from './detail.vue'
	import constantes from './constants.js'


	export default{
		components:{
			master, 
			detail
		},
		data (){
			return{
			}
		},
		computed:{

		},
		methods:{
			
		}
	}
</script>

<style></style>