<template>
    <div>
      <ul>
        <li v-for="deck in decks" :key="deck.id">{{ deck.name }}</li>
      </ul>
    </div>

    <div>
      <add-deck @refreshDecks="fetchDecks" />
    </div>
  </template>
  
  <script>
  import AddDeck from './AddDeck.vue';
  
  export default {
    components: { AddDeck },
    data() {
      return {
        decks: [],
      };
    },
    methods: {
      fetchDecks() {
        fetch('https://localhost:7287/deck')
          .then(response => response.json())
          .then(data => {
            this.decks = data;
          });
      },
    },
    mounted() {
      this.fetchDecks(); 
    },
  };
  </script>