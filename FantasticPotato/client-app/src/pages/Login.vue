<template>
    <div>
        <form class="login" @submit.prevent ="authorization">
            <h1>Sign in</h1>
            <label>Login or email</label>
            <input required v-model="form.login" type="text" placeholder="Name"/>
            <label>Password</label>
            <input required v-model="form.password" type="password" placeholder="Password"/>
            <hr/>
            <button type="submit">Войти</button>
        </form>
    </div>
</template>

<script>
    import myLoginRoutine from '../auth'
    export default {
        data(){
            return{
                form: {
                    login: "",
                    password: ""
                }
            }
        },
        methods: {
            authorization(){
                myLoginRoutine(this.form).then(res => {
                    if(res.request.response === "ErrorLogin"){
                        console.log("Неверный логин или пароль")
                    }
                    else {
                        this.$router.push('/')}
                    })
            }
        }
    }
</script>
<style>
    #app{
        margin-top: 60px;
    }
</style>
