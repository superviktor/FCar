<template>
    <div>
      <h1>Decks:</h1>
      <ul>
        <li v-for="deck in decks" :key="deck.id">{{ deck.name }}</li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        decks: []
      };
    },
    mounted() {
      this.fetchDecks();
    },
    methods: {
      async fetchDecks() {
        try {
          const response = await fetch('https://localhost:7287/deck');
          if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
          }
          const data = await response.json();  
          this.decks = data;  
        } catch (error) {
          console.error('Fetch error:', error);
        }
      },
    },
  };
  </script>
  