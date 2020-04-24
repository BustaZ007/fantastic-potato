<template>
    <div class="login-content">
        <form class="login-form" @submit.prevent ="authorization">
            <h1 class="login-h1">Sign in</h1>
            <label class="login-label">Login or email</label>
            <input class="login-input" required v-model="form.login" type="text" placeholder="Name"/>
            <label class="login-label">Password</label>
            <input class="login-input" required v-model="form.password" type="password" placeholder="Password"/>
            <hr/>
            <button class="login-button" type="submit">Войти</button>
            <p class="login-error" v-if="errorView">Ooops! {{error}}</p>
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
                },
                error: "",
                errorView: false
            }
        },
        methods: {
            authorization(){
                myLoginRoutine(this.form).then(res => {
                    let errors = ['User not found by email', 'User not found', 'Password mismatch!'];
                    if(errors.includes(res.data)){
                        this.error = res.data;
                        this.errorView = true;
                    }
                    else {
                        this.$router.push('/')
                    }
                })
            }
        }
    }
</script>
<style>
    .login-content{
        display: flex;
        justify-content: center;
        padding-top: 100px;
    }
    .login-form{
        display: flex;
        flex-flow: column;
        border: 1px solid #A9C5E0;
        border-radius: 10px;
        padding: 50px;
        width: 450px;
        height: 450px;
    }
    .login-h1{
        text-align: center;
        font-family: CustomFont;
        font-size: 50px;
    }
    .login-label{
        font-family: CustomFont;
        font-size: 25px;
    }
    .login-button{
        font-family: CustomFont;
        font-size: 30px;
        background: #E5E31F;
        border-radius: 10px;
        border: none;
    }
    .login-button:hover{
        background: #376A9A;
        color: #E5E31F;
        transition: 0.5s;
    }
    .login-error{
        text-align: center;
        font-family: CustomFont;
        color: red;
    }
    .login-input{
        font-family: CustomFont;
        border: 1px solid #A9C5E0;
        border-radius: 3px;
        padding: 5px;
        font-size: 20px;
    }
</style>
