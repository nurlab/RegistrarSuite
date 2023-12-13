export class UtilityService {  
  
  formatDate(date: string): string {
      try {
          const d = new Date(date);
          let month = '' + (d.getMonth() + 1);
          let day = '' + d.getDate();
          const year = d.getFullYear();
          if (month.length < 2) month = '0' + month;
          if (day.length < 2) day = '0' + day;
          return [year, month, day].join('-');
      } catch (error) {
        console.error('Error:', error);
        throw error; // Rethrow the error or handle it appropriately
      }
    }
  }
