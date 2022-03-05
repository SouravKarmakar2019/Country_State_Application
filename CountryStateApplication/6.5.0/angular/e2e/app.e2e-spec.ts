import { CountryStateApplicationTemplatePage } from './app.po';

describe('CountryStateApplication App', function() {
  let page: CountryStateApplicationTemplatePage;

  beforeEach(() => {
    page = new CountryStateApplicationTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
