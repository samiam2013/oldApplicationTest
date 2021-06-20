use strict;
use warnings;
use JSON;
use Data::Dumper;

my $json_file = '/home/sam/perl/MetroNet/DataValidation/Contacts.json';
open(FH, '<', $json_file) or die $!;
my $contents = "";
while(<FH>){
  $contents = $contents.$_;
}
close(FH);

my $json = JSON->new->allow_nonref;
my $contacts = $json->decode($contents);

my @sorted_contacts = sort { $a->{fullName} cmp $b->{fullName} } @$contacts;
my %cityErrors;

foreach my $item (@sorted_contacts) {
  my $name = $item->{fullName};
  my $city = $item->{cityName};
  my $phone = $item->{phoneNumber};
  my $email = $item->{emailAddress};
  my $invalids = 0;
  print $name." - ";
  my $eRegex = $email =~ /\A[a-zA-Z0-9\.]+@[a-zA-Z0-9]+\.[a-zA-Z]+\z/;
  #print "email: ".$email." ".$eRegex."\n";
  my $pRegex = $phone =~ m/\A[0-9- ]+\z/;
  #print "phone: ".$phone." ".$pRegex."\n";
  if ($eRegex && $pRegex){
    print "Valid";
  } elsif (!$eRegex && !$pRegex){
    print "Email and Phone are invalid.";
    $invalids = $invalids + 2;
  } elsif (!$eRegex) {
    print "Email is invalid.";
    $invalids++;
  } elsif (!$pRegex) {
    print "Phone is invalid.";
    $invalids++;
  }
  print "\n\n";
  $cityErrors{$city} = $invalids + ($cityErrors{$city}? $cityErrors{$city} : 0);
}

print "\n\n";

foreach my $city (sort {$cityErrors{$b} <=> $cityErrors{$a}} keys %cityErrors){
  print $city." - ".$cityErrors{$city}." errors \n\n";
}
